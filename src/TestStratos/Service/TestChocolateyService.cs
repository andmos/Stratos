using System;
using System.IO;
using System.Linq;
using System.Xml;
using Moq;
using Stratos.Helper;
using Stratos.Logging;
using Stratos.Service;
using TestStratos.Logging;
using TestStratos.TestData;
using Xunit;

namespace TestStratos.Service
{
	public class TestChocolateyService
	{
		private readonly Mock<ICommandService> m_commandServiceMock;
        private readonly Mock<IFileSystemService> m_fileSystemServiceMock;
        private readonly ILogFactory m_consoleLoggerFactory;

	    private ChocolateyService m_cut;

        private string TestListOfPackages => @"packageA|1.1.0
			packageB|2.0.0
			packageC|3.1.0";

		private string TestListOfPackagesWithInvalidPackage => @"packageA|1.1.0
			packageB|2.0.0
			packageB|v2.0.0
			packageC|3.1.0";

	    private readonly string[] FailedPackages = { "packageA", "packageB", "packageC" };

	    public TestChocolateyService()
	    {
	        m_commandServiceMock = new Mock<ICommandService>();
            m_fileSystemServiceMock = new Mock<IFileSystemService>();
            m_consoleLoggerFactory = new NLogConsoleFactory();
            
            m_cut = new ChocolateyService(m_commandServiceMock.Object, m_fileSystemServiceMock.Object, m_consoleLoggerFactory);
        }

        [Fact]
		public void ChocoVersion_ReturnsChocoVersionAsSemver() 
		{
			m_commandServiceMock.Setup(m => m.Execute("choco", "--version", true, true)).Returns("10.0.11");

			Assert.IsType<SemanticVersion>(m_cut.ChocoVersion());
		}

		[Fact]
		public void ChocoVersion_GiveCorrectChocoVersion_ReturnsCorrectSemver() 
		{
			m_commandServiceMock.Setup(m => m.Execute("choco", "--version", true, true)).Returns("10.0.11");
			var expectedSemver = SemanticVersion.Parse("10.0.11");

			var actualSemver = m_cut.ChocoVersion();

			Assert.Equal(expectedSemver, actualSemver);
		}

		[Fact]
		public void ChocoVersion_GivenNull_ReturnsEmptySemver() 
		{
			m_commandServiceMock.Setup(m => m.Execute("choco", "--version", true, true)).Returns("null");
			var expectedSemver = Stratos.Constants.EmptySemanticVersion;

			var actualSemver = m_cut.ChocoVersion();

			Assert.Equal(expectedSemver, actualSemver);
		}

		[Fact]
		public void InstalledPackages_GivenCorrectListOfPackages_ReturnsCorrectNumberOfNuGetPackageObjects() 
		{
			m_commandServiceMock.Setup(m => m.Execute("choco", "list -lo -r", true, true)).Returns(TestListOfPackages);
			var expectedNumberOfPacakge = 3;

			var acutalNumberOfPackages = m_cut.InstalledPackages().Count();

			Assert.Equal(expectedNumberOfPacakge, acutalNumberOfPackages);
		}

		[Fact]
		public void InstalledPacakges_GivenListOfPacakgesWithCorruptVersion_ReturnsCorrectPackages()
		{
			m_commandServiceMock.Setup(m => m.Execute("choco", "list -lo -r", true, true)).Returns(TestListOfPackagesWithInvalidPackage);
			var expectedNumberOfPacakge = 3;

			var acutalNumberOfPackages = m_cut.InstalledPackages().Count();

			Assert.Equal(expectedNumberOfPacakge, acutalNumberOfPackages);
		}

		[Fact]
		public void InstalledPacakges_GivenCorrectListOfPacakge_PacakgesHasCorrectSemver() 
		{
			m_commandServiceMock.Setup(m => m.Execute("choco", "list -lo -r", true, true)).Returns(TestListOfPackages);
			var expectedSemver = SemanticVersion.Parse("1.1.0");

			var acutalSemver = m_cut.InstalledPackages().First().Version;

			Assert.Equal(expectedSemver.Version, acutalSemver.Version);
		}

        [Fact]
	    public void FailedPackages_ReturnsPackagesWithCorrectVersions()
        {
            m_fileSystemServiceMock.Setup(fss => fss.DirectoryExists(It.IsAny<string>())).Returns(true);
            m_fileSystemServiceMock.Setup(fss => fss.FileExists(It.IsAny<string>())).Returns(true);
            m_fileSystemServiceMock.Setup(fss => fss.GetDirectories(It.IsAny<string>())).Returns(FailedPackages);
            var nuspecXml = new XmlDocument();
            nuspecXml.Load(new MemoryStream(Files.testpackage));
            m_fileSystemServiceMock.Setup(fss => fss.LoadXmlDocument(It.IsAny<string>())).Returns(nuspecXml);

            var failedPackages = m_cut.FailedPackages();

            Assert.Equal(3, failedPackages.Count());
            var packageA = failedPackages.Single(p => p.PackageName == "packageA");
            Assert.Equal(new Version("1.2.3.0"), packageA?.Version?.Version);
        }
	}
}
