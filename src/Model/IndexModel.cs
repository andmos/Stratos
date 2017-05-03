using System.Collections.Generic;
using Nancy.Routing;

namespace Stratos.Model
{
	public class IndexModel
	{
		public IEnumerable<RouteDescription> Routes { get; set; }
	}
}
