using System;
using LightInject;
using Nancy.Serialization.JsonNet;
using Newtonsoft.Json;
using Stratos.Helper;
using Stratos.Logging;
using Stratos.Service;
using TestStratos.Logging;
using TestStratos.Module;

namespace TestStratos
{
	public class TestCompositionRoot : ICompositionRoot
	{
    
        void ICompositionRoot.Compose(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register<ILogFactory, NLogConsoleFactory>(new PerContainerLifetime());
            serviceRegistry.Register<Type, ILog>((factory, type) => factory.GetInstance<ILogFactory>().GetLogger(type));
            serviceRegistry.RegisterConstructorDependency((factory, info) => factory.GetInstance<Type, ILog>(info.Member.DeclaringType));
            serviceRegistry.Register<ICommandService, TestableCommandServiceMock>();
            serviceRegistry.Register<IFileSystemService, FileSystemServiceStub>();
            serviceRegistry.Register<IChocolateyService>(factory => new ChocolateyService(factory.GetInstance<ICommandService>(), factory.GetInstance<IFileSystemService>(), factory.GetInstance<ILogFactory>()));
            serviceRegistry.Register<JsonNetSerializer, JsonNetSerializer>();
            serviceRegistry.Register<JsonSerializer, CustomJsonSerializer>();
            serviceRegistry.RegisterAssembly("*.Stratos.Plugin.dll");
        }
    }
}
