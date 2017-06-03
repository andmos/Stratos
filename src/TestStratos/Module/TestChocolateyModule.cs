using NuGet;
using Nancy;
using Nancy.Testing;
using Xunit;


namespace TestStratos
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

			var actualPackagesJson = result.Body.AsString();

			Assert.Equal(HttpStatusCode.OK, result.StatusCode);
			Assert.True(actualPackagesJson.Contains("\"minor\":1")); 

		}

	}
}
