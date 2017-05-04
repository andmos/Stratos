using Nancy;

namespace Stratos.Module
{
	public class PingModule : NancyModule
	{
		public PingModule() : base("/api/")
		{
            this.EnableCors();
			Get["/ping"] = parameters =>
			{
				var response = (Response)"pong";
				response.StatusCode = HttpStatusCode.OK;

				return response;
			};
		}
	}
}
