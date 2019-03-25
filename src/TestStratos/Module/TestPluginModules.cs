using System;
using Nancy;
using Nancy.Testing;
using Xunit;

namespace TestStratos.Module
{
    public class TestPluginModules
    {
    
        [Fact]
        public void PluginModule_givenPluginModule_ReturnsPluginModuleText()
        {
            var browser = new Browser(new TestableLightInjectNancyBootstrapper(), to => to.Accept("application/json"));

            var result = browser.Get("/api/testPlugin", with =>
            {
                with.HttpRequest();
            });

            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
            Assert.Equal("Hello From TestPlugin!", result.Body.AsString());
        }

        [Fact]
        public void PluginModule_givenPluginModuleWithLogger_ReturnsCorrectLogger()
        {
            var browser = new Browser(new TestableLightInjectNancyBootstrapper(), to => to.Accept("application/json"));

            var result = browser.Get("/api/testPluginLogger", with =>
            {
                with.HttpRequest();
            });

            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
            Assert.Contains("NLogConsoleFactory", result.Body.AsString());
        }
    }
}
