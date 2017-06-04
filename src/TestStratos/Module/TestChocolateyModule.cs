using Nancy;
using Nancy.Testing;
using Stratos.Helper;
using Xunit;

namespace TestStratos.Module
{
	public class TestChocolateyModule
	{
		[Fact]
		public void chocoVersion_returnsCorrectChocoVersion() 
		{
			var browser = new Browser(new TestableLightInjectNancyBootstrapper(), to => to.Accept("application/json"));
			var expectedVersion = SemanticVersion.Parse("10.0.11").ToNormalizedString();

			var result = browser.Get("/api/chocoVersion", with =>
				{
					with.HttpRequest();
				});

			Assert.Equal(HttpStatusCode.OK, result.StatusCode);
			Assert.Equal(expectedVersion, SemanticVersion.Parse(result.Body.DeserializeJson<string>()).ToNormalizedString());
		}



		[Fact]
		public void chocoPackages_returnsPackagesWithSemverString() 
		{
			var browser = new Browser(new TestableLightInjectNancyBootstrapper(), to => to.Accept("application/json"));

			var result = browser.Get("/api/chocoPackages", with =>
			{
				with.HttpRequest();			
			});

			var resultJson = result.Body.AsString(); 

			Assert.Equal(HttpStatusCode.OK, result.StatusCode);
			Assert.True(resultJson.Contains("major"));
			Assert.True(resultJson.Contains("minor"));
		}


	}
}
