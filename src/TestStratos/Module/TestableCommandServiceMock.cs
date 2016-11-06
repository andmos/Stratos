using System;
using Stratos.Service;

namespace TestStratos
{
	public class TestableCommandServiceMock : ICommandService
	{

		private string TestListOfPackagesWithInvalidPackage => @"packageA 1.1.0
			packageB 2.0.0
			packageB v2.0.0
			packageC 3.1.0";

		public string Execute(string commandPath, string arguments, bool quiet = false, bool returnOutput = false)
		{
			if (commandPath.Equals("choco") && arguments.Equals("--version"))
			{
				return "10.0.11";
			}

			if (commandPath.Equals("choco") && arguments.Equals("list -lo"))
			{
				return TestListOfPackagesWithInvalidPackage;
			}
			return string.Empty; 
		}
	}
}
