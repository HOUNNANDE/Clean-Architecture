using AspNetCore.Courses.Section15.Infrastructures.Infrastructures.ModelsEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AspNetCore.Courses.Section15.Infrastructures.Common
{
	public static class DeserializeJsonfile<someType> where someType : class			
	{ 
		
		
		public static List <someType> DbSet(string fileName)
		{
			if (string.IsNullOrEmpty(fileName))
			{
				throw new ArgumentNullException($"nameof{(fileName)} the file searched does'nt exist");
			}
			var dbSet = GetEntities(fileName);
			return dbSet.ToList();
		}

		public static IEnumerable<someType> GetEntities(string fileName)
		{
			
			string fullPath = ReadJsonfile.GetfilePath(fileName);

			string stringJson = File.ReadAllText(fullPath);

			if (!stringJson.Any())
			{
				throw new FileLoadException(nameof(stringJson));
			}
			var jsonOptions = new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true,
			};

			List<someType>? DbSet = JsonSerializer.Deserialize<List<someType>>(stringJson, jsonOptions);
			if (DbSet == null)
			{
				throw new Exception(nameof(DbSet));
			}
			return DbSet.ToList();
		}
	}
	
	
}
