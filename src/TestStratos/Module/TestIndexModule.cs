using System;
using Newtonsoft.Json;
using System.Linq;
using NuGet;
using Nancy;
using Nancy.Testing;
using Xunit;
using System.Collections.Generic;
using Stratos.Model;

namespace TestStratos
{
	public class TestIndexModule
	{
		[Fact]
		public void indexModule_returnsActiveNancyRoutes() 
		{
			var browser = new Browser(new DefaultNancyBootstrapper(), to => to.Accept("application/json"));

			var result = browser.Get("/api/", with =>
				{
					with.HttpRequest();
				});

			Assert.Equal(HttpStatusCode.OK, result.StatusCode);
			Assert.True(result.Body.AsString().Contains("GET"));
		}

		[Fact]
		public void indexModule_returnsItsOwnRoute() 
		{
			var browser = new Browser(new DefaultNancyBootstrapper(), to => to.Accept("application/json"));
			var result = browser.Get("/api/", with =>
			{
				with.HttpRequest(); 
			});
			Assert.Equal(HttpStatusCode.OK, result.StatusCode);
			Assert.True(result.Body.AsString().Contains(@"/api"));
		}

		[Fact]
		public void indexModule_returnsPingRoute()
		{
			var browser = new Browser(new DefaultNancyBootstrapper(), to => to.Accept("application/json"));
			var result = browser.Get("/api/", with =>
			{
				with.HttpRequest();
			});
			Assert.Equal(HttpStatusCode.OK, result.StatusCode);
			Assert.True(result.Body.AsString().Contains(@"/ping"));
		}


	}
}