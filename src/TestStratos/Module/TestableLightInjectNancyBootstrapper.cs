using System;
using Stratos.Service;
using LightInject;
using LightInject.Nancy;
using Moq;
using Nancy.Serialization.JsonNet;
using Nancy;
using Newtonsoft.Json;
using Stratos.Helper;

namespace TestStratos
{
	public class TestableLightInjectNancyBootstrapper : LightInjectNancyBootstrapper
	{
		protected override IServiceContainer GetServiceContainer()
		{
			IServiceContainer container = new ServiceContainer();

			container.Register<ICommandService, TestableCommandServiceMock>(new PerContainerLifetime());
			container.Register<IChocolateyService>(factory => new ChocolateyService(factory.GetInstance<ICommandService>()));
			container.Register<JsonNetSerializer, Nancy.Serialization.JsonNet.JsonNetSerializer>();
            container.Register<JsonSerializer, CustomJsonSerializer>();
            container.RegisterAssembly("*.Stratos.Plugin.dll");

			return container;
		}

       
           
        
    }
}
