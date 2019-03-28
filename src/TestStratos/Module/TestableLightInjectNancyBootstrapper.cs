using LightInject;
using LightInject.Nancy;

namespace TestStratos.Module
{
	public class TestableLightInjectNancyBootstrapper : LightInjectNancyBootstrapper
	{
		protected override IServiceContainer GetServiceContainer()
		{
			IServiceContainer container = new ServiceContainer();
            container.RegisterFrom<TestCompositionRoot>();

            return container;
		}
    }
}
