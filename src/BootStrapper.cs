using System;
using LightInject;
using LightInject.Nancy;
using Nancy;
using Newtonsoft.Json;
using Stratos.Helper;

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
	}

   
}
