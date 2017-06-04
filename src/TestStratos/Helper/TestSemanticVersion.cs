using Newtonsoft.Json;
using Stratos.Helper;
using Xunit;

namespace TestStratos.Helper
{
	public class TestSemanticVersion
	{
	[Fact]
	public void SemanticVersion_CheckIfJsonSerializationIsCorrect()
	{
		var semantic = new SemanticVersion(1, 2, 3, 5);

		var semanticJson = JsonConvert.SerializeObject(semantic);
		var deserializedSemanticVersion = JsonConvert.DeserializeObject<SemanticVersion>(semanticJson);

		Assert.Equal(semantic.Version, deserializedSemanticVersion.Version);

	}

	}
}
