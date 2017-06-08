using System;
using Stratos.Helper;
using Stratos.Model;
namespace Stratos
{
	public static class Constants
	{
		public static SemanticVersion EmptySemanticVersion => SemanticVersion.Parse("0.0.0.0");
		public static NuGetPackage EmptyNuGetPackage => new NuGetPackage { PackageName =  string.Empty, Version = new PackageVersion() {SpecialVersion = string.Empty, Version = EmptySemanticVersion.Version }  };
	}
}
