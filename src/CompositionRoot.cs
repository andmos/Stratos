using System;
using LightInject;
using Stratos.Logging;
using Stratos.Service;

namespace Stratos
{
	public class CompositionRoot : ICompositionRoot 
	{
		public void Compose(IServiceRegistry serviceRegistry)
		{
            serviceRegistry.Register<ILogFactory, NLogFactory>(new PerContainerLifetime());
            serviceRegistry.Register<Type, ILog>((factory, type) => factory.GetInstance<ILogFactory>().GetLogger(type));
            serviceRegistry.RegisterConstructorDependency((factory, info) => factory.GetInstance<Type, ILog>(info.Member.DeclaringType));
            serviceRegistry.Register<ICommandService, CommandService>(new PerContainerLifetime());
            serviceRegistry.Register<IFileSystemService, FileSystemService>(new PerContainerLifetime());
            serviceRegistry.Register<IChocolateyService>(factory => new ChocolateyService(factory.GetInstance<ICommandService>(), factory.GetInstance<IFileSystemService>(), factory.GetInstance<ILogFactory>()));
            serviceRegistry.RegisterAssembly("*.Stratos.Plugin.dll");
        }
	}
}
