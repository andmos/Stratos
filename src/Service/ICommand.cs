using System;
using System.Diagnostics;

namespace Stratos
{
	public interface ICommand
	{
		string Execute(string commandPath, string arguments, bool quiet = false, bool returnOutput = false);
	}
}
