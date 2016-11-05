using Nancy;
using Stratos.Service;

namespace Stratos.Module
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
			    return Response.AsJson(chocoVersion != Constants.EmptySemanticVersion ? chocoVersion.ToNormalizedString() : "Can't find Chocolatey Version, is Chocolatey installed or missing from path?");
			};
			
		}
	}
}
