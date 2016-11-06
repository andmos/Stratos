namespace Stratos.Service
{
	public interface ICommandService
	{
		string Execute(string commandPath, string arguments, bool quiet = false, bool returnOutput = false);
	}
}
