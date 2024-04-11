using AspNetCore.Courses.Section15.Infrastructures.DAL.DatabaseContexts;
using AspNetCore.Courses.Section15.Infrastructures.DAL.DatabaseContexts.CountryDb.Persistence;
using AspNetCore.Courses.Section15.Infrastructures.DAL.Repositories.Interfaces;
using AspNetCore.Courses.Section15.Infrastructures.Infrastructures.ModelsEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.Courses.Section15.Infrastructures.DAL.Repositories
{

	public class CountryRepository : ICountryRepository
	{
		private readonly PersonsDbContext _dbContext;
		public CountryRepository(PersonsDbContext dbContext) {
			_dbContext = dbContext;
		}
		public CountryEntityModel AddCountry(CountryEntityModel country)
		{
			_dbContext.CountriesDbSet.Add(country);

			return country;
		}

		public List<CountryEntityModel> GetAllCountries()
		{
			var countries = _dbContext.CountriesDbSet.ToList(); 
			return countries.ToList();
		}

		public CountryEntityModel GetCountryByCountryID(Guid? countryID)
		{
			
			var country = _dbContext.CountriesDbSet.Where(country=> country.CountryID== countryID).FirstOrDefault();
			if (country == null)
			{
				throw new Exception($"{ nameof(country)} searched country not found");
			
			}
			return country; 

		}
	}
}
