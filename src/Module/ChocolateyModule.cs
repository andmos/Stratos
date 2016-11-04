using System;
using Nancy;

namespace Stratos
{
	public class ChocolateyModule : NancyModule
	{
		private readonly IChocolateyService m_chocoService; 

		public ChocolateyModule(IChocolateyService chocoService) : base("/api/")
		{
			m_chocoService = chocoService; 

			Get["/chocolateyVersion"] = parameters =>
			{
				var response = (Response)"pong";
				response.StatusCode = HttpStatusCode.OK;

				return response;
			};
			
		}
	}
}
