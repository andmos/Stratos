using LightInject;
using Nancy.Conventions;
using TestStratosTestable.Stratos.Plugin.Service;

namespace TestStratosTestable.Stratos.Plugin
{
    public class CompositionRoot : ICompositionRoot
    {
        public void Compose(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register<IMyService, MyService>();
            serviceRegistry.Register(x => StaticContentConventionBuilder.AddDirectory("/", "Content"));
        }
    }
}