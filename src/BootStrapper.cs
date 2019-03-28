using System;
using LightInject;
using LightInject.Nancy;
using Nancy;
using Nancy.Bootstrapper;
using Newtonsoft.Json;
using Stratos.Helper;
using Stratos.Logging;

namespace Stratos
{
	public class BootStrapper : LightInjectNancyBootstrapper
	{
		protected override IRootPathProvider RootPathProvider => new Nancy.Hosting.Self.FileSystemRootPathProvider();

	    protected override void ConfigureApplicationContainer(IServiceContainer existingContainer)
	    {
	        base.ConfigureApplicationContainer(existingContainer);

            existingContainer.Register<JsonSerializer, CustomJsonSerializer>();
        }

		protected override void ApplicationStartup(IServiceContainer container, IPipelines pipelines)
		{
			var logger = container.GetInstance<ILogFactory>().GetLogger(GetType());
			logger.Info("Application startup");
			base.ApplicationStartup(container, pipelines);
		}

	}

   
}
