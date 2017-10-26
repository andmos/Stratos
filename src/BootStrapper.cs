using System;
using LightInject;
using LightInject.Nancy;
using Nancy;
using Nancy.Conventions;
using Newtonsoft.Json;
using Stratos.Helper;

namespace Stratos
{
	public class BootStrapper : LightInjectNancyBootstrapper
	{
		protected override IRootPathProvider RootPathProvider => new Nancy.Hosting.Self.FileSystemRootPathProvider();
        private IServiceContainer ServiceContainer { get; set; }

	    protected override void ConfigureApplicationContainer(IServiceContainer existingContainer)
	    {
	        base.ConfigureApplicationContainer(existingContainer);

	        existingContainer.RegisterFrom<CompositionRoot>();

            existingContainer.Register<JsonSerializer, CustomJsonSerializer>();
	        ServiceContainer = existingContainer;
	    }
        protected override void ConfigureConventions(NancyConventions nancyConventions)
        {
            var conventionPlugins = ServiceContainer.GetAllInstances<Func<NancyContext, string, Response>>();
            foreach (var convention in conventionPlugins)
            {
                nancyConventions.StaticContentsConventions.Add(convention);
            }
            
            base.ConfigureConventions(nancyConventions);
        }

    }
}
