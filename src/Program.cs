using Topshelf.Nancy;
using Topshelf;


namespace Stratos
{
	public class Program
	{
		static void Main(string[] args)
		{
			var host = HostFactory.New(x =>
			{
				x.UseLinuxIfAvailable();
				x.Service<StratosSelfHost>(s =>
				{
					s.ConstructUsing(settings => new StratosSelfHost());
					s.WhenStarted(service => service.Start());
					s.WhenStopped(service => service.Stop());
					s.WithNancyEndpoint(x, c =>
					{
						c.AddHost(port: 1337);
						c.CreateUrlReservationsOnInstall();
						c.OpenFirewallPortsOnInstall(firewallRuleName: "StratosService");
					});
				});
			
				x.StartAutomatically();
				x.SetServiceName("StratosService");
				x.SetDisplayName("StratosService");
				x.SetDescription("StratosService");
				x.RunAsNetworkService();
			
			});
			host.Run();
		}
	}
}
