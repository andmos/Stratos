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
	}
}