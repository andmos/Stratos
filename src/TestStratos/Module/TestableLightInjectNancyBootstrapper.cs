using System;
using Stratos.Service;
using LightInject;
using LightInject.Nancy;
using Moq;

namespace TestStratos
{
	public class TestableLightInjectNancyBootstrapper : LightInjectNancyBootstrapper
	{
		protected override IServiceContainer GetServiceContainer()
		{
			IServiceContainer container = new ServiceContainer();

			container.Register<ICommandService, TestableCommandServiceMock>(new PerContainerLifetime());
			container.Register<IChocolateyService>(factory => new ChocolateyService(factory.GetInstance<ICommandService>()));
			container.RegisterAssembly("*.Stratos.Plugin.dll");

			return container;
		}
	}
}
