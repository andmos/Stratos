using System.Collections.Generic;
using Stratos.Helper;
using Stratos.Model;

namespace Stratos.Service
{
	public interface IChocolateyService
	{
		SemanticVersion ChocoVersion();
		IEnumerable<NuGetPackage> InstalledPackages(); 
	}
}
