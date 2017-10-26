using Nancy;
using TestStratosTestable.Stratos.Plugin.Service;

namespace TestStratosTestable.Stratos.Plugin.Module
{
public class TestablePluginModule : NancyModule
{
	    public TestablePluginModule(IMyService myService) : base("/api/")
	    {
		    Get["/testPlugin"] = parameters => myService.GetValue();
	    }	
	}
}
