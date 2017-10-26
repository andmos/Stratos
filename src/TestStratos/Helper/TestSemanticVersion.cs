using Newtonsoft.Json;
using Stratos.Helper;
using Xunit;

namespace TestStratos.Helper
{
	public class TestSemanticVersion
	{
		[Theory]
		[InlineData(1, 2, 3, 5)]
		[InlineData(3, 5, 7, 2)]
		public void SemanticVersion_CheckIfJsonSerializationIsCorrect(int mayor, int minor, int build, int revision)
	    {
			var semantic = new SemanticVersion(mayor, minor, build, revision);

		    var semanticJson = JsonConvert.SerializeObject(semantic);
		    var deserializedSemanticVersion = JsonConvert.DeserializeObject<SemanticVersion>(semanticJson);

		    Assert.Equal(semantic.Version, deserializedSemanticVersion.Version);
	    }

		[Theory]
		[InlineData("5.2.3")]
		public void SemanticVersion_CheckIfJsonSerializationIsCorrect(string version)
		{
			var semantic = new SemanticVersion(version);

			var semanticJson = JsonConvert.SerializeObject(semantic);
			var deserializedSemanticVersion = JsonConvert.DeserializeObject<SemanticVersion>(semanticJson);

			Assert.Equal(semantic.Version, deserializedSemanticVersion.Version);
		}


	}
}
