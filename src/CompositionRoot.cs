using System;
using LightInject;
using Stratos.Service;

namespace Stratos
{
	public class CompositionRoot : ICompositionRoot 
	{
		public void Compose(IServiceRegistry serviceRegistry)
		{
			serviceRegistry.Register<ICommandService, CommandService>(new PerContainerLifetime());
			serviceRegistry.Register<IChocolateyService>(factory => new ChocolateyService(factory.GetInstance<ICommandService>()));
            serviceRegistry.RegisterAssembly("*.Stratos.Plugin.dll");
        }
	}
}
