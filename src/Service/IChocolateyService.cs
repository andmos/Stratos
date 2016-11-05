using NuGet;
using System;
using System.Collections.Generic;

namespace Stratos
{
	public interface IChocolateyService
	{
		SemanticVersion ChocoVersion();
		IEnumerable<NuGetPackage> InstalledPackages(); 
	}
}
