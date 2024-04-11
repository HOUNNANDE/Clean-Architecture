using AspNetCore.Courses.Section15.BusinessLogic.CountryBusinessLogic.Commons;
using AspNetCore.Courses.Section15.BusinessLogic.CountryBusinessLogic.CountryServices;
using AspNetCore.Courses.Section15.BusinessLogic.CountryBusinessLogic.DTO;
using AspNetCore.Courses.Section15.BusinessLogic.CountryBusinessLogic.Validation;
using AspNetCore.Courses.Section15.Infrastructures.DAL.DatabaseContexts;
using AspNetCore.Courses.Section15.Infrastructures.DAL.DatabaseContexts.CountryDb.Persistence;
using AspNetCore.Courses.Section15.Infrastructures.DAL.DatabaseContexts.PersonDb.Persistence;
using AspNetCore.Courses.Section15.Infrastructures.DAL.Repositories;
using AspNetCore.Courses.Section15.Infrastructures.DAL.Repositories.Interfaces;
using FluentValidation;
using Xunit.Abstractions;

namespace AspNetCore.Courses.Section15.XUnits.CountryServicesXUnits
{

    public class CountryServicesTests
    {

        private readonly ICountryServices _countryServices;
        private readonly ITestOutputHelper _outputHelper;
        private readonly IValidator<CountryRequestDTO> _countryValidator;
        private readonly ICountryRepository _countryRepository;
        private readonly DataBaseContext _dataBaseContext;
        private readonly IPersonDbContext _personDbContext;
		private readonly ICountryDbContext _countryDbContext;
		public CountryServicesTests(ITestOutputHelper outputHelper)
        {
            _countryValidator = new CountryValidation();
            _personDbContext = new PersonDataBaseContext();
			_countryDbContext = new CountryDataBaseContext();   
			_dataBaseContext = new DataBaseContext(_personDbContext, _countryDbContext);
            _countryRepository = new CountryRepository(_dataBaseContext);
			_countryServices = new CountryServices(_countryValidator, _countryRepository);
            _outputHelper = outputHelper;

        }


        #region AddCountry Xunit Tests

        /// <summary>
        /// Supply null argument to the addCountry request methods 
        /// must throw argument null expception
        /// </summary>
        [Fact]
        public void AddCountry_NullCountry_ArgumentNullException()
        {

            // Arrange 
            CountryRequestDTO? countryRequest = null;
            // Assert 
            Assert.Throws<ArgumentNullException>(() =>
            {
                //Action
                _countryServices.AddCountry(countryRequest);
            });
        }

        /// <summary>
        /// Supply null Country name to the country request addCountry
        /// must throw argument exception
        /// </summary>
        [Fact]
        public void AddCountry_EmptyCountry_ArgumentExeption()
        {
            CountryRequestDTO? countryRequest = new CountryRequestDTO()
            {
                CountryName = string.Empty,
            };

            Assert.Throws<ArgumentException>(() =>
            {
                _countryServices.AddCountry(countryRequest);

            });
        }

        /// <summary>
        /// supply duplicated country to country request 
        /// must throw argument exception 
        /// </summary>

        [Fact]
        public void AddCountry_DuplicatedCountryName_ArgumentException()
        {
            CountryRequestDTO? countryRequest1 = new CountryRequestDTO()
            {
                CountryName = "USA"
            };
            CountryRequestDTO? countryRequest2 = new CountryRequestDTO()
            {
                CountryName = "USA"
            };

            Assert.Throws<ArgumentException>(() =>
            {
                _countryServices.AddCountry(countryRequest1);
                _countryServices.AddCountry(countryRequest2);
            });

        }


        [Fact]
        public void AddCountry_CountryIDCreation_GuidIDNotNull()
        {
            CountryRequestDTO? countryRequest = new CountryRequestDTO()
            {
                CountryName = "Benin"
            };

            CountryResponseDTO countryResponse = _countryServices.AddCountry(countryRequest);

            Assert.True(countryResponse.CountryID != Guid.Empty);
            _outputHelper.WriteLine(countryResponse.CountryName);
            _outputHelper.WriteLine((countryResponse.CountryID).ToString());


        }


        [Fact]
		public void AddCountry_AddCountryResquest_ReturnCountryResponse()
		{
			CountryRequestDTO? countryRequest = new CountryRequestDTO()
			{
				CountryName = "Spain"
			};

			CountryResponseDTO countryResponse = _countryServices.AddCountry(countryRequest);

			Assert.True(countryResponse.CountryID != Guid.Empty);
			_outputHelper.WriteLine(countryResponse.CountryName);
			_outputHelper.WriteLine((countryResponse.CountryID).ToString());


		}

		#endregion

		#region  GetAllCountry XUnit Tests

		/// <summary>
		/// keep the countries list empty.
		/// throw assert empty list exception
		/// </summary>
		[Fact]
        public void GetAllCountries_EmptyList_ThrowException()
        {
            Assert.Throws<Exception>(() => _countryServices.GetAllCountries());
        }


        /// <summary>
        /// Return a list of countries that matches the list of added countries
        /// </summary>
        [Fact]
        public void GetAllCountries_AddSomeCountries_ReturnCountriesList()
        {
            var countriesRequestDTO = new List<CountryRequestDTO>()
            {

                new CountryRequestDTO() { CountryName = "Allemagne" },
                new CountryRequestDTO() { CountryName = "Philipine" },
                new CountryRequestDTO() { CountryName = "South Africa" },
            };

            List<CountryResponseDTO> expectedCountries = new List<CountryResponseDTO>();
           
            foreach(CountryRequestDTO countryRequest in countriesRequestDTO)
            {    
                var countryResponse = _countryServices.AddCountry(countryRequest);
				expectedCountries.Add(countryResponse);
			}

			List<CountryResponseDTO> actualCountries = _countryServices.GetAllCountries();

            foreach(CountryResponseDTO countryResponse in actualCountries)
            {
                Assert.Contains(countryResponse, expectedCountries); 
            }
		}

        #endregion

        #region  GetCountryByCountryID


        /// <summary>
        /// receive a null country ID
        /// Throw argumentNUllExeception
        /// </summary>
        [Fact]
        public void GetCountryBycountryID_NullCountryID_ThrowArgumentNullException()
        {
            // Arrange
            Guid ? countryID = null;

            // Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                //Action
                _countryServices.GetCountryByCountryID(countryID);
            });
        }

        /// <summary>
        /// Fecth country in the country data base given the country ID
        /// Throws argument exception if the return list is empty
        /// </summary>
		[Fact]
		public void GetCountryByCountryID_EmptyCountriesList_ThrowException()
		{
			// Keep the list of country empty
           
            // build a random country and supply the country ID to the method
            CountryRequestDTO countryRequest = new CountryRequestDTO() { CountryName = "South of Core" };
            var countryrRequest = CountryRequestsMapper.BuildCountry(countryRequest);
            var countryResponse = CountryResponsesMapper.SendCountry(countryrRequest);
            

            Assert.Throws<Exception>(() =>
            {
				_countryServices.GetCountryByCountryID(countryResponse.CountryID);
			});
		}

        /// <summary>
        ///fetched country from the countries List 
        /// Take a random object early supplied and fetched the same country by its ID
        /// return the same object 
        /// </summary>
		[Fact]
		public void GetCountryByCountryID_SafeCountryID()
		{
            // Build a list of countries request to be added to the data base 

            List<CountryRequestDTO> countriesRequest = new List<CountryRequestDTO>()
            {
                new CountryRequestDTO () {CountryName ="France"},
                new CountryRequestDTO() { CountryName= "USA" },
                new CountryRequestDTO() {CountryName = "United Kingdom"}
            };

            List<CountryResponseDTO> countriesListExpected = new List<CountryResponseDTO>(); 
            
            foreach(CountryRequestDTO countryRequest in countriesRequest)
            {
				 var countryResponse = _countryServices.AddCountry(countryRequest);
                countriesListExpected.Add(countryResponse); 
			}
            
            // fetched all countries 
            var countriesResponses = _countryServices.GetAllCountries();

			CountryResponseDTO? countryResponseRnd = countriesListExpected.FirstOrDefault();
            var countryID = countryResponseRnd?.CountryID;


			CountryResponseDTO? countryResponseFetchedByID = _countryServices.GetCountryByCountryID(countryID);

            Assert.Contains(countryResponseFetchedByID, countriesResponses); 
		}






		#endregion


	}
}
