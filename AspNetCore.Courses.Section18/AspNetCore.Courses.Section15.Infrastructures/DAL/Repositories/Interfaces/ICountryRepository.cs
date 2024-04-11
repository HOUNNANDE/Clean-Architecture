using AspNetCore.Courses.Section15.Infrastructures.Infrastructures.ModelsEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.Courses.Section15.Infrastructures.DAL.Repositories.Interfaces
{
	public interface ICountryRepository
	{
		public CountryEntityModel AddCountry(CountryEntityModel country);
		public List<CountryEntityModel> GetAllCountries();
		public CountryEntityModel GetCountryByCountryID(Guid? countryID);
	}
}
