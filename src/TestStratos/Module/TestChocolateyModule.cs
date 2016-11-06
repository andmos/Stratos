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

	}
}
