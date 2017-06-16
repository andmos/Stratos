using Nancy;
using Stratos.Service;

namespace Stratos.Module
{
	public class ChocolateyModule : NancyModule
	{
		private readonly IChocolateyService m_chocoService;

		public ChocolateyModule(IChocolateyService chocoService) : base("/api/")
		{
            this.EnableCors();
            StaticConfiguration.DisableErrorTraces = false;
			m_chocoService = chocoService;

			Get["/chocoVersion"] = parameters =>
			{
				var chocoVersion = m_chocoService.ChocoVersion();
				return Response.AsJson(chocoVersion != Constants.EmptySemanticVersion ? chocoVersion.ToNormalizedString() : "Can't find Chocolatey Version, is Chocolatey installed or missing from path?");
			};


			Get["/chocoPackages"] = parameters =>
			{
				var chocoPackages = m_chocoService.InstalledPackages();
				return Response.AsJson(chocoPackages);
			};

            Get["/failedChocoPackages"] = parameters =>
            {
                var failedPackages = m_chocoService.FailedPackages();
                return Response.AsJson(failedPackages);
            };

        }
	}
}
