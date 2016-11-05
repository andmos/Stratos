using NuGet;

namespace Stratos.Model
{
	public class NuGetPackage
	{
		public string PackageName { get; set;} 
		public SemanticVersion Version { get; set; }
	}
}
