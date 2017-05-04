using System;
using System.Linq;
using Moq;
using NuGet;
using Stratos.Service;
using Xunit;

namespace TestStratos
{
	public class TestChocolateyService
	{
		private Mock<ICommandService> commandServiceMock;
		private string TestListOfPackages => @"packageA|1.1.0
			packageB|2.0.0
			packageC|3.1.0";

		private string TestListOfPackagesWithInvalidPackage => @"packageA|1.1.0
			packageB|2.0.0
			packageB|v2.0.0
			packageC|3.1.0";



		[Fact]
		public void ChocoVersion_ReturnsChocoVersionAsSemver() 
		{
			commandServiceMock = new Mock<ICommandService>();
			commandServiceMock.Setup(m => m.Execute("choco", "--version", true, true)).Returns("10.0.11");

			var chocolateyService = new ChocolateyService(commandServiceMock.Object);

			Assert.IsType<SemanticVersion>(chocolateyService.ChocoVersion());
		}

		[Fact]
		public void ChocoVersion_GiveCorrectChocoVersion_ReturnsCorrectSemver() 
		{
			commandServiceMock = new Mock<ICommandService>();
			commandServiceMock.Setup(m => m.Execute("choco", "--version", true, true)).Returns("10.0.11");
			var chocolateyService = new ChocolateyService(commandServiceMock.Object);
			var expectedSemver = SemanticVersion.Parse("10.0.11");

			var actualSemver = chocolateyService.ChocoVersion();

			Assert.Equal(expectedSemver, actualSemver);

		}

		[Fact]
		public void ChocoVersion_GivenNull_ReturnsEmptySemver() 
		{
			commandServiceMock = new Mock<ICommandService>();
			commandServiceMock.Setup(m => m.Execute("choco", "--version", true, true)).Returns("null");
			var chocolateyService = new ChocolateyService(commandServiceMock.Object);
			var expectedSemver = Stratos.Constants.EmptySemanticVersion;

			var actualSemver = chocolateyService.ChocoVersion();

			Assert.Equal(expectedSemver, actualSemver);
		}

		[Fact]
		public void InstalledPackages_GivenCorrectListOfPackages_ReturnsCorrectNumberOfNuGetPackageObjects() 
		{
			commandServiceMock = new Mock<ICommandService>();
			commandServiceMock.Setup(m => m.Execute("choco", "list -lo -r", true, true)).Returns(TestListOfPackages);
			var chocolateyService = new ChocolateyService(commandServiceMock.Object);
			var expectedNumberOfPacakge = 3;

			var acutalNumberOfPackages = chocolateyService.InstalledPackages().Count();

			Assert.Equal(expectedNumberOfPacakge, acutalNumberOfPackages);

		
		}

		[Fact]
		public void InstalledPacakges_GivenListOfPacakgesWithCorruptVersion_ReturnsCorrectPackages()
		{
			commandServiceMock = new Mock<ICommandService>();
			commandServiceMock.Setup(m => m.Execute("choco", "list -lo -r", true, true)).Returns(TestListOfPackagesWithInvalidPackage);
			var chocolateyService = new ChocolateyService(commandServiceMock.Object);
			var expectedNumberOfPacakge = 3;

			var acutalNumberOfPackages = chocolateyService.InstalledPackages().Count();

			Assert.Equal(expectedNumberOfPacakge, acutalNumberOfPackages);
		}

		[Fact]
		public void InstalledPacakges_GivenCorrectListOfPacakge_PacakgesHasCorrectSemver() 
		{
			commandServiceMock = new Mock<ICommandService>();
			commandServiceMock.Setup(m => m.Execute("choco", "list -lo -r", true, true)).Returns(TestListOfPackages);
			var chocolateyService = new ChocolateyService(commandServiceMock.Object);
			var expectedSemver = SemanticVersion.Parse("1.1.0");

			var acutalSemver = chocolateyService.InstalledPackages().FirstOrDefault().Version;

			Assert.Equal(expectedSemver, acutalSemver);
		}

	}
}
