using System;
using Nancy;

namespace Stratos
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
