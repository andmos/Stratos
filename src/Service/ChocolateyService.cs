using System;
using System.Collections.Generic;

namespace Stratos
{
	public class ChocolateyService : IChocolateyService
	{
		public int ChocoVersion()
		{
			throw new NotImplementedException();
		}

		public IEnumerable<NuGetPackage> InstalledPackages()
		{
			throw new NotImplementedException();
		}
	}
}
