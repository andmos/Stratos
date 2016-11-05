namespace Stratos.Service
{
	public interface ICommand
	{
		string Execute(string commandPath, string arguments, bool quiet = false, bool returnOutput = false);
	}
}
