using System;
using Nancy;

namespace TestStratosTestable.Stratos.Plugin
{
public class TestablePluginModule : NancyModule
{
	public TestablePluginModule() : base("/api/")
	{
		Get["/testPlugin"] = parameters =>
		{
			return "Hello From TestPlugin!";
		};
	}	
	}
}
