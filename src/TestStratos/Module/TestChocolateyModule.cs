using NuGet;
using Nancy;
using Nancy.Testing;
using Xunit;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Linq;
using System;

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
			int expectedNumberOfSemanticVersionObjects = 3; 

			var result = browser.Get("/api/chocoPackages", with =>
			{
				with.HttpRequest();			
			});
				
			var actualSemanticVersions = GetSemanticVersionFromJSON(result.Body.AsString()); 

			Assert.Equal(HttpStatusCode.OK, result.StatusCode);
			Assert.True(actualSemanticVersions.Count() == expectedNumberOfSemanticVersionObjects); 
		}

		private IEnumerable<SemanticVersion> GetSemanticVersionFromJSON(string jsonString) 
		{
			var versionString = JArray.Parse(jsonString);

			var semanticVersionJsonResult = new List<JToken>();
			foreach (var jtoken in versionString) 
			{
				semanticVersionJsonResult.Add(jtoken["version"]["version"]);
			}

			var semanticVersions = new List<SemanticVersion>();

			foreach (var jsonToken in semanticVersionJsonResult) 
			{
				SemanticVersion version = new SemanticVersion(major: int.Parse(jsonToken["major"].ToString()), minor: int.Parse(jsonToken["minor"].ToString()), build: int.Parse(jsonToken["build"].ToString()), revision: int.Parse(jsonToken["revision"].ToString()));
				semanticVersions.Add(version);

			}
			return semanticVersions; 

		}

	}
}
