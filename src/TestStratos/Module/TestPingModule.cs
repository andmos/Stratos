using System;
using Nancy;
using Nancy.Testing;
using Xunit;

namespace TestStratos
{
	public class TestPingModule
	{
		[Fact]
		public void Ping_ReturnsPong() 
		{
			var browser = new Browser(new DefaultNancyBootstrapper(), to => to.Accept("application/json"));

			var result = browser.Get("/api/ping", with =>
				{
					with.HttpRequest();
				});

			Assert.Equal(HttpStatusCode.OK, result.StatusCode);
			Assert.Equal("pong", result.Body.AsString());
		}
	}
}
