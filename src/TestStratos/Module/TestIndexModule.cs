using Nancy;
using Nancy.Testing;
using Xunit;

namespace TestStratos.Module
{
	public class TestIndexModule
	{
		[Fact]
		public void IndexModule_returnsActiveNancyRoutes() 
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
		public void IndexModule_returnsItsOwnRoute() 
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
		public void IndexModule_returnsPingRoute()
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