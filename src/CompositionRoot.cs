using System.Collections.Generic;
using LightInject;
using Stratos.Service;  

namespace Stratos
{
	public class CompositionRoot : ICompositionRoot
	{
		public void Compose(IServiceRegistry serviceRegistry)
		{
            serviceRegistry.Register<ICommandService, CommandService>(new PerContainerLifetime());
            serviceRegistry.Register<IFileSystemService, FileSystemService>(new PerContainerLifetime());
            serviceRegistry.Register<IChocolateyService>(factory => new ChocolateyService(factory.GetInstance<ICommandService>(), factory.GetInstance<IFileSystemService>()));
            serviceRegistry.RegisterAssembly("*.Stratos.Plugin.dll");
        }
	}
}
