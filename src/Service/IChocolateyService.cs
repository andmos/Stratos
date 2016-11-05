using System.Collections.Generic;
using NuGet;
using Stratos.Model;

namespace Stratos.Service
{
	public interface IChocolateyService
	{
		SemanticVersion ChocoVersion();
		IEnumerable<NuGetPackage> InstalledPackages(); 
	}
}
