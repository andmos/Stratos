using LightInject;
using LightInject.Nancy;
using Nancy.Serialization.JsonNet;
using Newtonsoft.Json;
using Stratos.Helper;
using Stratos.Service;

namespace TestStratos.Module
{
	public class TestableLightInjectNancyBootstrapper : LightInjectNancyBootstrapper
	{
		protected override IServiceContainer GetServiceContainer()
		{
			IServiceContainer container = new ServiceContainer();

			container.Register<ICommandService, TestableCommandServiceMock>(new PerContainerLifetime());
            container.Register<IFileSystemService, FileSystemServiceStub>(new PerContainerLifetime());
            container.Register<IChocolateyService>(factory => new ChocolateyService(factory.GetInstance<ICommandService>(), factory.GetInstance<IFileSystemService>()));
			container.Register<JsonNetSerializer, JsonNetSerializer>();
            container.Register<JsonSerializer, CustomJsonSerializer>();
            container.RegisterAssembly("*.Stratos.Plugin.dll");

			return container;
		}
    }
}
