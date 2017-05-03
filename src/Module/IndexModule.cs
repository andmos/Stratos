using System.Collections.Generic;
using System.Linq;
using Nancy;
using Nancy.Routing;
using Stratos.Model;

namespace Stratos
{
	public class IndexModule : NancyModule
	{
		private IRouteCacheProvider m_routeCache;

		public IndexModule(IRouteCacheProvider routeCache) : base("/api/")
		{
			m_routeCache = routeCache;
			Get["/"] = parameters =>
			{
				var responseObject = new IndexModel();
				var cache = m_routeCache.GetCache();

				responseObject.Routes = cache.Values.SelectMany(t => t.Select(t1 => t1.Item2));

				return Response.AsJson(responseObject.Routes.Select(p => new KeyValuePair<string, string>(p.Path, p.Method)));
			};
		}
	}
}