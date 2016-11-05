using Nancy;

namespace Stratos.Module
{
	public class PingModule : NancyModule
	{
		public PingModule() : base("/api/")
		{
			Get["/ping"] = parameters =>
			{
				var response = (Response)"pong";
				response.StatusCode = HttpStatusCode.OK;

				return response;
			};
		}
	}
}
