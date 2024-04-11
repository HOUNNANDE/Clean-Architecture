using AspNetCore.Courses.Section15.BusinessLogic.CountryBusinessLogic.Commons;
using AspNetCore.Courses.Section15.BusinessLogic.CountryBusinessLogic.DTO;
using AspNetCore.Courses.Section15.Infrastructures.Infrastructures.ModelsEntities;
using FluentValidation.Results;
using System.Data;
using FluentValidation;
using AspNetCore.Courses.Section15.Infrastructures.DAL.Repositories.Interfaces;

namespace AspNetCore.Courses.Section15.BusinessLogic.CountryBusinessLogic.CountryServices
{
    public class CountryServices : ICountryServices
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IValidator<CountryRequestDTO> _countryValidator;


        public CountryServices( IValidator<CountryRequestDTO> countryValidator, ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
			_countryValidator = countryValidator;
        }

        #region AddCountry Methods

        public CountryResponseDTO AddCountry(CountryRequestDTO? countryRequestDTO)
        {
            if (countryRequestDTO == null)
            {
                throw new ArgumentNullException(nameof(countryRequestDTO));
            }

             ValidationResult countryRequestValidation = _countryValidator.Validate(countryRequestDTO);

            bool isValideCountryRequest = countryRequestValidation.IsValid;
           
            if (!isValideCountryRequest) {
                
                throw new ArgumentException(nameof(countryRequestDTO)); 
            }

            /*
			var duplicateCountryQuery = _countries.Where(country => country.CountryName == countryRequestDTO.CountryName);
          
            if (duplicateCountryQuery.Count() > 0)
            {
                throw new ArgumentException($"{nameof(duplicateCountryQuery)} can't be duplicated");
            }
            */


            CountryEntityModel country = CountryRequestsMapper.BuildCountry(countryRequestDTO);

			_countryRepository.AddCountry(country);

            CountryResponseDTO countryResponse = CountryResponsesMapper.SendCountry(country);

            return countryResponse;
        }

        public List<CountryResponseDTO> GetAllCountries()
        {
            var allCountries = _countryRepository.GetAllCountries();

            var countriesResponse = allCountries.Select(country => CountryResponsesMapper.SendCountry(country));

            return countriesResponse.ToList();
        }

        public CountryResponseDTO GetCountryByCountryID(Guid? countryID)
        {
            if (countryID == null)
            {
                throw new ArgumentNullException(nameof(countryID));
            }

            var country = _countryRepository.GetCountryByCountryID(countryID);  
                
             var countryResponse = CountryResponsesMapper.SendCountry(country);
            return countryResponse;
        }
		public CountryResponseDTO GetCountryByCountryName(string CountryName)
		{
			if (string.IsNullOrEmpty(CountryName))
			{
				throw new ArgumentNullException(nameof(CountryName));
			}

            var countries = _countryRepository.GetAllCountries();
                
            var country = countries.Where(countryReponse => countryReponse.CountryName == CountryName).FirstOrDefault();

			if (country == null)
			{   
                // if country does't exist in the countries Database, a new country will be created with a country ID
                CountryRequestDTO countryRequest = new CountryRequestDTO() { CountryName = CountryName};
                var createCountry = AddCountry(countryRequest);

                return createCountry;
			}

            return CountryResponsesMapper.SendCountry(country) ; 
		}

		#endregion
	}
}
