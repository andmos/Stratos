using System;
using NuGet;
namespace Stratos
{
	public class NuGetPackage
	{
		public string PackageName { get; set;} 
		public SemanticVersion Version { get; set; }
	}
}
