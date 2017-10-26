using Nancy;

namespace TestStratosTestable.Stratos.Plugin.Module
{
    public class TestablePluginViewModule : NancyModule
    {
        public TestablePluginViewModule() : base("/")
        {
            Get["/testPlugin"] = parameters => Response.AsFile("Content/Views/index.html", "text/html");
        }
    }
}