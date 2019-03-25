using Topshelf.Nancy;
using Topshelf;

namespace Stratos
{
	public class Program
	{
		private const int Port = 1337;
		private const string ApiEndpoint = "/api/";

		static void Main(string[] args)
		{
			var host = HostFactory.New(x =>
        {
				x.UseLinuxIfAvailable();
				x.Service<StratosSelfHost>(s =>
				{
					s.ConstructUsing(settings => new StratosSelfHost($"http://+:{Port}{ApiEndpoint}"));
					s.WhenStarted(service => service.Start());
					s.WhenStopped(service => service.Stop());
					s.WithNancyEndpoint(x, c =>
					{
						c.AddHost(port: Port);
						c.CreateUrlReservationsOnInstall();
						c.OpenFirewallPortsOnInstall(firewallRuleName: "StratosService");
					});
				});

				x.StartAutomatically();
				x.SetServiceName("StratosService");
				x.SetDisplayName("StratosService");
				x.SetDescription("StratosService");
                x.RunAsLocalSystem();

        });

			host.Run();
		}
	}
}
