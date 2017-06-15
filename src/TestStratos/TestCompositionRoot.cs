using LightInject;
using Moq;
using Stratos.Service;

namespace TestStratos
{
	public class TestCompositionRoot : ICompositionRoot
	{
		private string TestListOfPackagesWithInvalidPackage => @"packageA 1.1.0
			packageB 2.0.0
			packageB v2.0.0
			packageC 3.1.0";
		
		public void Compose(IServiceRegistry serviceRegistry)
		{
			var testableCommandMock = new Mock<ICommandService>();
			testableCommandMock.Setup(m => m.Execute("choco", "list -lo", true, true)).Returns(TestListOfPackagesWithInvalidPackage);
			testableCommandMock.Setup(m => m.Execute("choco", "--version", true, true)).Returns("10.0.11");

			serviceRegistry.RegisterInstance<ICommandService>(testableCommandMock.Object);
            serviceRegistry.RegisterInstance<IFileSystemService>(new Mock<IFileSystemService>().Object);
            serviceRegistry.Register<IChocolateyService>(factory => new ChocolateyService(factory.GetInstance<ICommandService>(), factory.GetInstance<IFileSystemService>()));
		}
	}
}
