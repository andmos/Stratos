using System;
using LightInject.Nancy;
using Nancy;

namespace Stratos
{
	public class BootStrapper : LightInjectNancyBootstrapper
	{
		protected override IRootPathProvider RootPathProvider
		{
			get { return new Nancy.Hosting.Self.FileSystemRootPathProvider(); }
		}
	}
}
