using System;
using System.Collections.Generic;
using System.Linq;
using NuGet;
using NuGet.Resources;
using Stratos.Model;

namespace Stratos.Service
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
				var version = SemanticVersion.Parse(m_command.Execute("choco", "--version", true, true));
				return version;
			}
			catch (Exception ex)
			{
				return Constants.EmptySemanticVersion;
			}
		}

		public IEnumerable<NuGetPackage> InstalledPackages()
		{
			try
			{
				return ParsePackagesOutput(m_command.Execute("choco", "list -lo", true, true));
			}
			catch (Exception ex) 
			{
				return new List<NuGetPackage> { Constants.EmptyNuGetPackage }; 
			}
		}

		private IEnumerable<NuGetPackage> ParsePackagesOutput(string outputString) 
		{
			var packages = new List<NuGetPackage>();
			var rawPackageOutput = outputString.Split('\n');
			foreach (var textString in rawPackageOutput)
			{
                var packageSplit = textString.Split(' ');
                try
			    {
                    packages.Add(new NuGetPackage { PackageName = packageSplit[0], Version = SemanticVersion.Parse(packageSplit[1]) });
                }
			    catch (Exception ex)
			    {
			        // Should logg this or something.
			    } 
               
			}
			return packages;


		}
	}
}
