using System;
using Nancy;
using NuGet;

namespace Stratos
{
	public class ChocolateyModule : NancyModule
	{
		private readonly IChocolateyService m_chocoService; 

		public ChocolateyModule(IChocolateyService chocoService) : base("/api/")
		{
			StaticConfiguration.DisableErrorTraces = false;
			m_chocoService = chocoService; 

			Get["/chocolateyVersion"] = parameters =>
			{
				var chocoVersion = m_chocoService.ChocoVersion();
				if (chocoVersion != Constants.EmptySemanticVersion)
				{
					return Response.AsJson(chocoVersion);
				}
				else 
				{
					return Response.AsJson("Can't find Chocolatey Version, is Chocolatey installed or missing from path?");
				}
			};
			
		}
	}
}
