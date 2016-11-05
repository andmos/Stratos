using System;
using NuGet;
using Stratos.Model;
namespace Stratos
{
	public static class Constants
	{
		public static SemanticVersion EmptySemanticVersion => SemanticVersion.Parse("0.0.0.0");
		public static NuGetPackage EmptyNuGetPackage => new NuGetPackage { PackageName =  string.Empty, Version = EmptySemanticVersion };
	}
}
