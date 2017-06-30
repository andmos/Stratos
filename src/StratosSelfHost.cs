using System;
namespace Stratos
{
	public class StratosSelfHost
	{
		public StratosSelfHost(string listeningInfo) 
		{
			Console.WriteLine($"Stratos listening on: {listeningInfo}");
		}

		public bool Start()
		{
			return true;
		}

		public bool Stop()
		{
			return false;
		}

	}
}
