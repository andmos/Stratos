using System;
using System.Collections.Generic;

namespace Stratos
{
	public interface IChocolateyService
	{
		int ChocoVersion();
		IEnumerable<NuGetPackage> InstalledPackages(); 
	}
}
