Plugin-support
===
Stratos can be extended with it's own plugins. To write a plugin, create a new project and
reference the following NuGet-packages:

```
LightInject
LightInject.Nancy
Nancy
```

The project can be named whatever, but must end in `*.Stratos.Plugin.dll`.

A Nancy module is needed like so:

```
using Demo.Stratos.Plugin.Services;
using Nancy;

namespace Demo.Stratos.Plugin.Module
{
    public class PluginModule : NancyModule
    {
        private readonly IFoo m_foo;
        public PluginModule(IFoo foo) : base("api/plugin/")
        {
            EnableCors();
            m_foo = foo;
            Get["/getString"] = parameters =>
            {
                var result = m_foo.GetString();
                return Response.AsJson(result);
            };
        }

        private void EnableCors()
        {
            After.AddItemToEndOfPipeline(x => { x.Response.WithHeader("Access-Control-Allow-Origin", "*"); });
        }
    }
}

```

Along side a `CompositionRoot` that implements the interfaces used by the module:

```
using Demo.Stratos.Plugin.Services;
using LightInject;

namespace Demo.Stratos.Plugin
{
    public class CompositionRoot : ICompositionRoot
    {
        public void Compose(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register<IFoo, Foo>(new PerRequestLifeTime());
        }
    }
}
```

And that's it. Build the new DLL's and put them along side the other Stratos DLL's and the module should be available.

For working code example, [see this reference project](https://github.com/andmos/StratosPluginExample).
