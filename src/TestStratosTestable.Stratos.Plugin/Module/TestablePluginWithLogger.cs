using System;
using Nancy;
using Stratos.Logging;

namespace TestStratosTestable.Stratos.Plugin.Module
{
    public class TestablePluginWithLogger : NancyModule
    {

        public TestablePluginWithLogger(ILogFactory logFactory) : base("/api/")
        {

            Get["/testPluginLogger"] = parameters =>
            {
                return logFactory.GetType();
            };
        }
    }
}
