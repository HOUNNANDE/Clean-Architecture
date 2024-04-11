using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.Courses.Section15.Infrastructures.Common
{
	public static class ReadJsonfile
	{
		public static string GetfilePath(string fileName)
		{
			string workingDirectory= @"C:\Users\mhounnande\Desktop\DevOps.NET\Courses\BackEndCourses\AspNetCore.Courses.Section15\DataBase";

			if (!Directory.Exists(workingDirectory))
			{
				throw new FileNotFoundException(nameof(workingDirectory));
			}

			if (string.IsNullOrEmpty(fileName))
			{
				throw new Exception(nameof(fileName));	
			}
			var fullPath = Path.GetFullPath(workingDirectory);
			string datafilePath = Path.Combine(fullPath, fileName);

			return datafilePath;
		}
	}
}
