using System;
using NuGet;
using System.Collections.Generic;

namespace Stratos
{
	public class ChocolateyService : IChocolateyService
	{
		private readonly ICommand m_command; 

		public ChocolateyService(ICommand command) 
		{
			m_command = command; 
		}

		public SemanticVersion ChocoVersion()
		{
			try
			{
				var version = SemanticVersion.Parse(m_command.Execute("choco", "--version", true));
				return version;
			}
			catch (Exception ex)
			{
				return Constants.EmptySemanticVersion;
			}
		}

		public IEnumerable<NuGetPackage> InstalledPackages()
		{
			throw new NotImplementedException();
		}
	}
}
