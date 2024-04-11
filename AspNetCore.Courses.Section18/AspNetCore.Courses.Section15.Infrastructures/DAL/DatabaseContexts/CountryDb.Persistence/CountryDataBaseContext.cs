using AspNetCore.Courses.Section15.Infrastructures.Common;
using AspNetCore.Courses.Section15.Infrastructures.Infrastructures.ModelsEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AspNetCore.Courses.Section15.Infrastructures.DAL.DatabaseContexts.CountryDb.Persistence
{
	public class CountryDataBaseContext : ICountryDbContext
	{
		public List<CountryEntityModel> CountryDbSet
		{
			get
			{
				string fileName = "CountryDataBase.json";
				return DeserializeJsonfile<CountryEntityModel>.DbSet(fileName);
			}

		
		}

	}
}

