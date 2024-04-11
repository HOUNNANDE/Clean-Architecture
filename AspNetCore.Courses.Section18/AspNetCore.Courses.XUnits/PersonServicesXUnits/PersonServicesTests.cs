#region Namespaces 

using AspNetCore.Courses.Section15.BusinessLogic.CountryBusinessLogic.CountryServices;
using AspNetCore.Courses.Section15.BusinessLogic.CountryBusinessLogic.DTO;
using AspNetCore.Courses.Section15.BusinessLogic.CountryBusinessLogic.PersonServices;
using AspNetCore.Courses.Section15.BusinessLogic.CountryBusinessLogic.Validation;
using AspNetCore.Courses.Section15.BusinessLogic.PersonBusinessLogic.BusinessCalculation;
using AspNetCore.Courses.Section15.BusinessLogic.PersonBusinessLogic.Commons;
using AspNetCore.Courses.Section15.BusinessLogic.PersonBusinessLogic.DTO;
using AspNetCore.Courses.Section15.BusinessLogic.PersonBusinessLogic.Enum;
using AspNetCore.Courses.Section15.BusinessLogic.PersonBusinessLogic.PersonDTO;
using AspNetCore.Courses.Section15.BusinessLogic.PersonBusinessLogic.Validation;
using AspNetCore.Courses.Section15.Infrastructures.DAL.DatabaseContexts;
using AspNetCore.Courses.Section15.Infrastructures.DAL.DatabaseContexts.CountryDb.Persistence;
using AspNetCore.Courses.Section15.Infrastructures.DAL.DatabaseContexts.PersonDb.Persistence;
using AspNetCore.Courses.Section15.Infrastructures.DAL.Repositories;
using AspNetCore.Courses.Section15.Infrastructures.DAL.Repositories.Interfaces;
using FluentValidation;
using Xunit.Abstractions;

#endregion

namespace AspNetCore.Courses.Section15.XUnits.PersonServicesXUnits
{

	public class PersonServicesTests
	{
		#region Interfaces and dbcontext 
		private readonly IPersonServices _personServices;
		private readonly ITestOutputHelper _outputHelper;
		private readonly IPersonBusinessCalculation _personBusinessCalculation;
		private readonly ICountryServices _countryServices;
		private readonly IValidator<PersonRequestDTO> _personRequestValidator;
		private readonly IValidator<PersonUpdateRequestDTO> _personUpdateRequestValidator;
		private readonly IValidator<CountryRequestDTO> _countryRequestValidator;
		private readonly DataBaseContext _dbContext;
		private readonly IPersonDbContext _personDbContext;
		private readonly ICountryDbContext _countryDbContext;
		private readonly IPersonRepository _personRepository;
		private readonly ICountryRepository _countryRepository;

		#endregion

		public PersonServicesTests(ITestOutputHelper testOutHelper)
		{
			_countryRequestValidator = new CountryValidation(); 
			_personBusinessCalculation = new PersonBusinessCalculation();
			_personRequestValidator = new PersonValidation();
			_personUpdateRequestValidator = new UpdatePersonValidation();

			_personDbContext = new PersonDataBaseContext();
			_countryDbContext = new CountryDataBaseContext();	
			_dbContext = new DataBaseContext(_personDbContext, _countryDbContext);
			_personRepository = new PersonRepository(_dbContext);
			_countryRepository = new CountryRepository(_dbContext);

			_countryServices = new CountryServices(_countryRequestValidator, _countryRepository);
			_personServices = new PersonServices(_countryServices, _personBusinessCalculation, _personRequestValidator,
				_personUpdateRequestValidator, _personRepository);
			_outputHelper = testOutHelper;
		}

		#region Tests AddPerson Services
		/// <summary>
		/// take a null person request argument
		/// must throw argument null exception 
		/// </summary>
		/// <param name="countryRequestDTO"></param>
		/// 

		[Fact]
		public void AddPerson_NullPersonRequest_ThrowArgumentNullException()
		{
			PersonRequestDTO? personRequest = null;
			Assert.Throws<ArgumentNullException>(() => _personServices.AddPerson(personRequest));
		}

		[Fact]
		public void AddPerson_PersonRequestWithNullPersonName_ThrowAgrumentException()
		{

			PersonRequestDTO personRequest = new PersonRequestDTO()
			{
				PersonName = string.Empty,
				Email = "person@example.com",
				DateOfBirth = new DateTime(1998, 12, 31),
				CountryName = "Benin",
				Gender = GenderOptions.Male,
				Address = "Adress 125891"


			};
			Assert.Throws<ArgumentException>(() => _personServices.AddPerson(personRequest));
		}


		[Fact]
		public void AddPerson_PersonRequest_CreatePersonID()
		{
			PersonRequestDTO personRequest = new PersonRequestDTO()
			{
				PersonName = "Person",
				Email = "person@example.com",
				DateOfBirth = new DateTime(1998, 12, 31),
				CountryName = "Benin",
				Gender = GenderOptions.Male,
				Address = "Adress 125891"
			};

			PersonResponseDTO? personResponse = _personServices.AddPerson(personRequest);
			Assert.True(personResponse.PersonID != Guid.Empty);
		}


		#endregion

		#region
		// Empty Person List 
		// Add some persons in the personList and must return the same persons; 

		/// <summary>
		/// Keep the List of persons empty.
		/// throw 
		/// </summary>

		[Fact]
		public void GetAllPersons_EmptyListOfPerson_ThrowException()
		{
			Assert.Throws<Exception>(() => _personServices.GetAllPersons());
		}

		[Fact]
		public void GetAllPersons_NotEmptyListOfPersons_ReturnListOfPersons()
		{
			List<PersonRequestDTO> personsRequests = new List<PersonRequestDTO>()
			{
				new PersonRequestDTO() {
				PersonName = "Person1",
				Email = "person1@example.com",
				DateOfBirth = new DateTime(1998, 12, 31),
				CountryName = "Benin",
				Gender = GenderOptions.Female,
				Address = "Adress 125891"
				},
				new PersonRequestDTO() {
				PersonName = "Person2",
				Email = "person2@example.com",
				DateOfBirth = new DateTime(1995, 10, 31),
				CountryName = "Benin",
				Gender = GenderOptions.Male,
				Address = "Adress 23659"
				},
				new PersonRequestDTO() {
				PersonName = "Person3",
				Email = "person3@example.com",
				DateOfBirth = new DateTime(1990, 05, 31),
				CountryName = "Benin",
				Gender = GenderOptions.Male,
				Address = "Adress 256598"

				}
			};

			List<PersonResponseDTO> personsResponseExpected = new List<PersonResponseDTO>();

			foreach (PersonRequestDTO personRequest in personsRequests)
			{
				var personsResponse = _personServices.AddPerson(personRequest);
				personsResponseExpected.Add(personsResponse);
			}
			var allPersons = _personServices.GetAllPersons();



			Assert.Equal(allPersons, personsResponseExpected);
		}


		#endregion

		#region GetPersonsByPersonID tests

		/// first : null personID must throw argument Null Exception
		/// second : if person infos fetched from the data base is null , then throw exception => Not found
		/// third : person is fetched succesfully and then person must be return bacl to the controller



		/// <summary>
		/// Supply null PersonID to the method 
		/// Throw AgrumentNullException 
		/// </summary>

		[Fact]
		public void GetPersonByPersonID_PersonIDNull_ThrowArgumentNullException()
		{
			Guid? personID = null;

			Assert.Throws<ArgumentNullException>(() =>
			{
				_personServices.GetPersonByPersonID(personID);
			});

		}

		/// <summary>
		/// Supply personID 
		/// PersonID supplied is not founded in the DataBase 
		/// Exception is thrown
		/// </summary>
		/// 
		[Fact]
		public void GetPersonByPersonID_PersonID_ReturnNullValue()
		{

			// Add single person to the DataBase ; 


			List<PersonRequestDTO> personRequests = new List<PersonRequestDTO>()
			{
			 new PersonRequestDTO(){
				PersonName = "Person3",
				Email = "person3@example.com",
				DateOfBirth = new DateTime(1990, 05, 31),
				CountryName = "Benin",
				Gender = GenderOptions.Male,
				Address = "Adress 256598"
			},

			 new PersonRequestDTO(){
				PersonName = "Person2",
				Email = "person2@example.com",
				DateOfBirth = new DateTime(1990, 05, 31),
				CountryName = "Benin",
				Gender = GenderOptions.Female,
				Address = "Adress 256598"

			}
		};
			foreach (PersonRequestDTO personRequest in personRequests)
			{
				_personServices.AddPerson(personRequest);
			}


			// Generate a random Guid to be used to fetch the person  ; 
			Guid personID = Guid.NewGuid();

			Assert.Throws<Exception>(() =>
			{
				_personServices.GetPersonByPersonID(personID);
			});

		}

		/// <summary>
		/// Supply a personID 
		/// Return a person Object 
		/// </summary>
		[Fact]

		public void GetPersonByPersonID_PersonID_ReturnPerson()
		{

			// Add single person to the DataBse ; 

			List<PersonRequestDTO> personRequests = new List<PersonRequestDTO>()
			{
			 new PersonRequestDTO(){
				PersonName = "Person3",
				Email = "person3@example.com",
				DateOfBirth = new DateTime(1990, 05, 31),
				CountryName = "Benin",
				Gender = GenderOptions.Male,
				Address = "Adress 256598"
			},

			 new PersonRequestDTO(){
				PersonName = "Person2",
				Email = "person2@example.com",
				DateOfBirth = new DateTime(1990, 05, 31),
				CountryName = "Benin",
				Gender = GenderOptions.Female,
				Address = "Adress 2552569"

			}
		};

			List<PersonResponseDTO> personResponsesExpected = new List<PersonResponseDTO>();

			foreach (PersonRequestDTO personRequest in personRequests)
			{
				personResponsesExpected.Add(_personServices.AddPerson(personRequest));
			}

			// Get firstordefault person id from the expected list

			var person = personResponsesExpected.Select(person => person).FirstOrDefault();
			var PersonID = person?.PersonID;


			PersonResponseDTO fetchedPerson = _personServices.GetPersonByPersonID(PersonID);

			Assert.Equal(fetchedPerson, person);
		}

		#endregion

		#region GetFilteredPersons
		/// Descriptions///
		/// Search Persons List by a Searchby and Search String 
		/// if SearchBy or the SearchString is Null it will return the original list of persons 
		/// if SearchBy is not null and the searchString is Not null, it return the correct filtred list 


		/// <summary>
		/// supply null searchBy and searchString parameters to the method. 
		/// return the original list 
		/// </summary>
		[Fact]
		public void GetFilteredPersons_SearchByNullOrSearchStringNull_ReturnOriginalListOfPersons()
		{
			string? searchBy = null;
			string? searchString = null;

			List<PersonRequestDTO> personRequests = new List<PersonRequestDTO>()
			{
			 new PersonRequestDTO(){
				PersonName = "Person3",
				Email = "person3@example.com",
				DateOfBirth = new DateTime(1990, 05, 31),
				CountryName = "Benin",
				Gender = GenderOptions.Male,
				Address = "Adress 256598"
			},

			 new PersonRequestDTO(){
				PersonName = "Person2",
				Email = "person2@example.com",
				DateOfBirth = new DateTime(1990, 05, 31),
				CountryName = "Benin",
				Gender = GenderOptions.Female,
				Address = "Adress 2552569"

			} ,

			new PersonRequestDTO(){
			PersonName = "Ambroisine",
			Email = "ambroisine@example.com",
			DateOfBirth = new DateTime(1990, 05, 31),
			CountryName = "Benin",
			Gender = GenderOptions.Female,
			Address = "Adress 2552569"

			}

			};

			// add the person request list to the list of persons ; 

			var data = new List<PersonResponseDTO>();

			// add the person request list to the list of persons ; 
			foreach (PersonRequestDTO personRequest in personRequests)
			{
				var personResponseDTO = _personServices.AddPerson(personRequest);
				data.Add(personResponseDTO);
			}

			List<PersonResponseDTO> filteredPersons = _personServices.GetFilteredPersons(searchBy, searchString);
			Assert.Equal(filteredPersons, data);
		}



		[Fact]
		public void GetFilteredPersons_SearchBySearchString_filtered()
		{

			List<PersonRequestDTO> personRequests = new List<PersonRequestDTO>()
			{
			 new PersonRequestDTO(){
				PersonName = "Person3",
				Email = "person3@example.com",
				DateOfBirth = new DateTime(1990, 05, 31),
				CountryName = "Benin",
				Gender = GenderOptions.Male,
				Address = "Adress 256598"
			},

			 new PersonRequestDTO(){
				PersonName = "Person2",
				Email = "person2@example.com",
				DateOfBirth = new DateTime(1990, 05, 31),
				CountryName = "Benin",
				Gender = GenderOptions.Female,
				Address = "Adress 2552569"

			} ,

			new PersonRequestDTO(){
			PersonName = "Ambroisine",
			Email = "ambroisine@example.com",
			DateOfBirth = new DateTime(1990, 05, 31),
			CountryName = "Benin",
			Gender = GenderOptions.Female,
			Address = "Adress 2552569"

			}

			};

			var data = new List<PersonResponseDTO>();

			// add the person request list to the list of persons ; 
			foreach (PersonRequestDTO personRequest in personRequests)
			{
				var personResponseDTO = _personServices.AddPerson(personRequest);
				data.Add(personResponseDTO);
			}

			string? searchBy = nameof(PersonRequestDTO.PersonName);
			string? searchString = "pers";

			List<PersonResponseDTO> filteredPersons = _personServices.GetFilteredPersons(searchBy, searchString);

			// filter manually the list
			List<PersonResponseDTO> personsManuallyFilters = data.Where(person => person.PersonName != null
					  && person.PersonName.Contains(searchString, StringComparison.OrdinalIgnoreCase)).ToList();
			Assert.Equal(filteredPersons, personsManuallyFilters);

		}


		#endregion


		#region  GetSortedPersons
		/// Description 
		/// Default column to sort : personName, default sort order : ASC
		/// the method takes three arguments : list of persons, column used to sort and sort criteria
		/// if column to sort is null or sort order too, it return the original list 
		/// if right information are provided the it return the sorted list 


		[Fact]
		public void GetSortedPersons_NullSortColumnNullOrderCriteria_ReturnOriginalPersonsList()
		{

			List<PersonRequestDTO> personRequests = new List<PersonRequestDTO>()
			{
			 new PersonRequestDTO(){
				PersonName = "Person3",
				Email = "person3@example.com",
				DateOfBirth = new DateTime(1990, 05, 31),
				CountryName = "Benin",
				Gender = GenderOptions.Male,
				Address = "Adress 256598"
			},

			 new PersonRequestDTO(){
				PersonName = "Person2",
				Email = "person2@example.com",
				DateOfBirth = new DateTime(1990, 05, 31),
				CountryName = "Benin",
				Gender = GenderOptions.Female,
				Address = "Adress 2552569"

			} ,

			new PersonRequestDTO(){
			PersonName = "Ambroisine",
			Email = "ambroisine@example.com",
			DateOfBirth = new DateTime(1990, 05, 31),
			CountryName = "Benin",
			Gender = GenderOptions.Female,
			Address = "Adress 2552569"

			}

			};

			var data = new List<PersonResponseDTO>();

			// add the person request list to the list of persons ; 
			foreach (PersonRequestDTO personRequest in personRequests)
			{
				var personResponseDTO = _personServices.AddPerson(personRequest);
				data.Add(personResponseDTO);
			}

			string? sortBy = null;
			SortOptions? sortOption = null;

			var persons = _personServices.GetAllPersons();
			List<PersonResponseDTO> sortPersons = _personServices.GetSortedPersons(persons, sortBy, sortOption);
			Assert.Equal(persons, sortPersons);


		}


		[Fact]
		public void GetSortedPersons_SortColumnOrderCriteria_ReturnSortedPersonsList()
		{

			List<PersonRequestDTO> personRequests = new List<PersonRequestDTO>()
			{
			 new PersonRequestDTO(){
				PersonName = "Person3",
				Email = "person3@example.com",
				DateOfBirth = new DateTime(1990, 05, 31),
				CountryName = "Benin",
				Gender = GenderOptions.Male,
				Address = "Adress 256598"
			},

			 new PersonRequestDTO(){
				PersonName = "Person2",
				Email = "person2@example.com",
				DateOfBirth = new DateTime(1990, 05, 31),
				CountryName = "Benin",
				Gender = GenderOptions.Female,
				Address = "Adress 2552569"

			} ,

			new PersonRequestDTO(){
			PersonName = "Ambroisine",
			Email = "ambroisine@example.com",
			DateOfBirth = new DateTime(1990, 05, 31),
			CountryName = "Benin",
			Gender = GenderOptions.Female,
			Address = "Adress 2552569"

			}

			};

			var data = new List<PersonResponseDTO>();

			// add the person request list to the list of persons ; 
			foreach (PersonRequestDTO personRequest in personRequests)
			{
				var personResponseDTO = _personServices.AddPerson(personRequest);
				data.Add(personResponseDTO);
			}

			string? sortBy = nameof(PersonResponseDTO.PersonName);
			SortOptions? sortOption = SortOptions.ASC;

			var persons = _personServices.GetAllPersons();
			List<PersonResponseDTO> sortPersons = _personServices.GetSortedPersons(persons, sortBy, sortOption);

			// sort the list Manually 

			var sortedExpectedList = data.OrderBy(person => person.PersonName).ToList();

			for (int i = 0; i < sortedExpectedList.Count; i++)
			{
				Assert.Equal(sortPersons[i], sortedExpectedList[i]);
			}


		}
		#endregion


		#region
		/// Description: 
		///Udapte Request can't be null
		///Validate request => Fluent Validation
		///Find the person to be updated using the person id
		/// Call Udapte Service 
		/// Find COuntry by Country Name 
		/// Update country ID 
		/// Send Back The response 
		#endregion
		
		
		
		[Fact]
		public void UpdatePerson_NullUpdateRequest_ThrowsArgumentNullException()
		{
			PersonUpdateRequestDTO? updateRequest = null;

			Assert.Throws<ArgumentNullException>(() =>
			{
				_personServices.UpdatePerson(updateRequest);
			});
		}

		[Fact]
		public void UpdatePerson_PersonNameNull_ThrowsArgumentException()
		{

			PersonUpdateRequestDTO updateRequest =
			new PersonUpdateRequestDTO()
			{
				PersonName = string.Empty,
				Email = "ambroisine@example.com",
				DateOfBirth = new DateTime(1990, 05, 31),
				CountryName = "Benin",
				Address = "Adress 2552569"

			};

			Assert.Throws<ArgumentException>(() =>
			{

				_personServices.UpdatePerson(updateRequest);
			});
		}

		[Fact]
		public void UpdatePerson_ValideRequest_ReturnUpdatePerson()
		{

			// add person to the DataBase 
			PersonRequestDTO personRequest =
			new PersonRequestDTO()
			{
				PersonName = "Ambroisine",
				Email = "ambroisine@example.com",
				DateOfBirth = new DateTime(1990, 05, 31),
				CountryName = "Benin",
				Address = "Adress 2552569"
			};

			PersonResponseDTO personResponse = _personServices.AddPerson(personRequest);


			PersonUpdateRequestDTO updateRequest =
				new PersonUpdateRequestDTO()
				{
					PersonID = personResponse.PersonID,
					PersonName = "Alphone",
					Email = "Alphonse@example.com",
					DateOfBirth = new DateTime(1990, 05, 31),
					CountryName = "Cameroun",
					Address = "Adress 2552569"

				};

			PersonResponseDTO personUpdate = _personServices.UpdatePerson(updateRequest);

			Assert.True(personUpdate.PersonID!=Guid.Empty);
			Assert.True(personUpdate.PersonName != personResponse.PersonName);
			Assert.True(personUpdate.Email != personResponse.Email);
		}
	}
}
