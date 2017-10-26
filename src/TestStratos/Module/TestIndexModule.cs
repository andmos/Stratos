using Nancy;
using Nancy.Testing;
using Xunit;

namespace TestStratos.Module
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

		[Fact]
		public void indexModule_givenPluginModule_ReturnsModuleEndpointInIndex()
		{
			var browser = new Browser(new TestableLightInjectNancyBootstrapper(), to => to.Accept("application/json"));

			var result = browser.Get("/api/testPlugin", with =>
			{
				with.HttpRequest();
			});

			Assert.Equal(HttpStatusCode.OK, result.StatusCode);
			Assert.True(result.Body.AsString().Contains("Hello From TestPlugin!"));
		}
	}
}