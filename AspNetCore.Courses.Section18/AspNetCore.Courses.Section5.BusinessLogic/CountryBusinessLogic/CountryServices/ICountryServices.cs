using AspNetCore.Courses.Section15.BusinessLogic.CountryBusinessLogic.DTO;
using System.Globalization;

namespace AspNetCore.Courses.Section15.BusinessLogic.CountryBusinessLogic.CountryServices
{
    /// <summary>
    /// Handle CRUD Operation from the DataBase
    /// </summary>
    public interface ICountryServices
    {
        public CountryResponseDTO AddCountry(CountryRequestDTO? countryRequestDTO);
        public List<CountryResponseDTO> GetAllCountries();
        public CountryResponseDTO GetCountryByCountryID(Guid? countryID);
		public CountryResponseDTO GetCountryByCountryName(string CountryName);

	}
}
