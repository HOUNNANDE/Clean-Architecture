using AspNetCore.Courses.Section15.BusinessLogic.CountryBusinessLogic.DTO;
using AspNetCore.Courses.Section15.Infrastructures.Infrastructures.ModelsEntities;

namespace AspNetCore.Courses.Section15.BusinessLogic.CountryBusinessLogic.Commons
{


    public class CountryResponsesMapper
    {
        /// <summary>
        /// receive a readonly object from the data base 
        /// </summary>
        /// <returns>
        /// send the response back to the browser 
        /// </returns>
        public static CountryResponseDTO SendCountry(CountryEntityModel country)
        {
            CountryResponseDTO countryResponse = new CountryResponseDTO()
            {
                CountryID = country.CountryID,
                CountryName = country.CountryName,
            };

            return countryResponse;
        }


    }
}
