using AspNetCore.Courses.Section15.BusinessLogic.CountryBusinessLogic.DTO;
using AspNetCore.Courses.Section15.Infrastructures.Infrastructures.ModelsEntities;

namespace AspNetCore.Courses.Section15.BusinessLogic.CountryBusinessLogic.Commons
{
    public static class CountryRequestsMapper
    {

        /// <summary>
        /// receive request from the browser and create a country object 
        /// generate new guid to set country id 
        /// </summary>
        /// <returns>
        /// return a country object to be added to the data base
        /// </returns>
        public static CountryEntityModel BuildCountry(CountryRequestDTO countryRequest)
        {
            CountryEntityModel country = new CountryEntityModel()
            {
                CountryID = Guid.NewGuid(),
                CountryName = countryRequest.CountryName
            };
            return country;
        }

	}
}
