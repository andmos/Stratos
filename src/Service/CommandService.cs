using System;
using System.Diagnostics;

namespace Stratos.Service
{
	public class CommandService : ICommandService
	{
		
		public string Execute(string commandPath, string arguments, bool quiet = false, bool returnOutput = false)
		{
			var startInformation = CreateProcessStartInfo(commandPath, arguments);
			var process = CreateProcess(startInformation);
			SetVerbosityLevel(process, quiet);
			var output = RunAndWait(process, returnOutput);
			CheckIfSuccessfull(process.ExitCode, commandPath);
			return output;
		}

		private static ProcessStartInfo CreateProcessStartInfo(string commandPath, string arguments)
		{
            var startInformation = new ProcessStartInfo(StringUtils.Quote(commandPath));

            startInformation.CreateNoWindow = true;
			startInformation.Arguments = arguments;
			startInformation.UseShellExecute = false;
			startInformation.RedirectStandardOutput = true;
			startInformation.RedirectStandardError = true;

			return startInformation;
		}

		private static Process CreateProcess(ProcessStartInfo startInformation)
		{
			var process = new Process();
			process.StartInfo = startInformation;
			return process;
		}

		private static void SetVerbosityLevel(Process process, bool quiet)
		{
			if (!quiet)
			{
				process.OutputDataReceived += (s, e) => Write.Info(e.Data);
				process.ErrorDataReceived += (s, e) => Write.Error(e.Data);
			}
		}

		private static string RunAndWait(Process process, bool returnOutput)
		{
			process.Start();
			string output = null;
			if (returnOutput)
			{
				output = process.StandardOutput.ReadToEnd();
			}
			else
			{
				process.BeginOutputReadLine();
			}

			process.BeginErrorReadLine();
			process.WaitForExit();
			return output;
		}

		private static void CheckIfSuccessfull(int exitCode, string commandPath)
		{
			if (exitCode != 0 && commandPath != "robocopy")
			{
				throw new Exception();
			}
		}
	}

	public static class Write
	{
		public static void Error(string message, bool newline = true)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.Write(message);
			if (newline) Console.WriteLine();
			Console.ResetColor();
		}

		public static void Info(string message, bool newline = true)
		{
			Console.Write(message);
			if (newline) Console.WriteLine();
		}

		public static void Warning(string message, bool newline = true)
		{
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.Write(message);
			if (newline) Console.WriteLine();
			Console.ResetColor();
		}

		public static void Caption(string message, bool newline = true)
		{
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.Write(message);
			if (newline) Console.WriteLine();
			Console.ResetColor();
		}
	}

	public static class StringUtils
	{
		public static string Quote(string value)
		{
			return "\"" + value + "\"";
		}
	}
}
