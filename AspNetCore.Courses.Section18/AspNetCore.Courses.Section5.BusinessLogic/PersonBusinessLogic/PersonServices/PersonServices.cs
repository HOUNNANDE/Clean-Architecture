#region Namespaces for Person Services
using AspNetCore.Courses.Section15.BusinessLogic.CountryBusinessLogic.Commons;
using AspNetCore.Courses.Section15.BusinessLogic.CountryBusinessLogic.CountryServices;
using AspNetCore.Courses.Section15.BusinessLogic.CountryBusinessLogic.DTO;
using AspNetCore.Courses.Section15.BusinessLogic.PersonBusinessLogic.BusinessCalculation;
using AspNetCore.Courses.Section15.BusinessLogic.PersonBusinessLogic.Commons;
using AspNetCore.Courses.Section15.BusinessLogic.PersonBusinessLogic.PersonDTO;
using AspNetCore.Courses.Section15.Infrastructures.Infrastructures.ModelsEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using System.Reflection.Metadata.Ecma335;
using AspNetCore.Courses.Section15.BusinessLogic.PersonBusinessLogic.Enum;
using AspNetCore.Courses.Section15.BusinessLogic.PersonBusinessLogic.DTO;
using AspNetCore.Courses.Section15.Infrastructures.DAL.Repositories.Interfaces;
using AspNetCore.Courses.Section15.Infrastructures.DAL.Repositories;

#endregion
namespace AspNetCore.Courses.Section15.BusinessLogic.CountryBusinessLogic.PersonServices
{
    public class PersonServices : IPersonServices
	{
		private readonly ICountryServices _countryServices;
		private readonly IPersonBusinessCalculation _personBusinessCalculation;
		private readonly IValidator<PersonRequestDTO> _personValidator;
		private readonly IValidator<PersonUpdateRequestDTO> _personUpdateValidaor;
		
		private readonly IPersonRepository _personRepository;


		public PersonServices(ICountryServices countryService, IPersonBusinessCalculation personBusinessCalculation,
			IValidator<PersonRequestDTO> personValidator, IValidator<PersonUpdateRequestDTO> personUpdateValidaor, 
			IPersonRepository personRepository)
		{
			_countryServices = countryService;
			_personBusinessCalculation = personBusinessCalculation;
			_personValidator = personValidator;
			_personUpdateValidaor = personUpdateValidaor;
			_personRepository = personRepository;
		}
		

		public PersonResponseDTO AddPerson(PersonRequestDTO? personRequestDTO)
		{
			if (personRequestDTO == null) {
				throw new ArgumentNullException(nameof(personRequestDTO));
			}

			string ? countryName = personRequestDTO.CountryName;
			var country = (!string.IsNullOrEmpty(countryName)) ?
				_countryServices.GetCountryByCountryName(countryName): null; // to be completed. this service must create a new country id if not exist


			var person = PersonRequestsMapper.BuildPerson(personRequestDTO); // map the person request to person model entity 

			_personRepository.AddPerson(person);

			var personResponseDTO = PersonResponsesMapper.SendPerson(person); // map the person response object with the person domain object 
			
			DateTime? DateOfBirth = person.DateOfBirth;

			personResponseDTO.Age = (DateOfBirth!=null) ? _personBusinessCalculation.GetPersonAge(DateOfBirth): null;

			return personResponseDTO;	
		}




		public List<PersonResponseDTO> GetAllPersons()
		{
			var queryPersons = _personRepository.GetAllPersons();

			if (!queryPersons.Any())
			{
				throw new Exception($"{nameof(queryPersons)} the data base is empty");
			}
			
			var personsResponses = queryPersons.Select(person => PersonResponsesMapper.SendPerson(person));
			

			return personsResponses.ToList(); 
		}

		public PersonResponseDTO GetPersonByPersonID(Guid? personID)
		{
			if (personID == null)
			{
				throw new  ArgumentNullException(nameof(personID)); 
			}

			PersonEntityModel? personFectched = _personRepository.GetPersonByPersonID(personID);

			PersonResponseDTO personResponse= PersonResponsesMapper.SendPerson(personFectched); 

			return personResponse; 
		}

		public List<PersonResponseDTO> GetFilteredPersons(string? searchBy, string? searchString)
		{
			List<PersonResponseDTO> filteredPersons = new List<PersonResponseDTO>();	
			List<PersonResponseDTO> allPersons = GetAllPersons();

			if (string.IsNullOrEmpty(searchBy) ||
				string.IsNullOrEmpty(searchString))
			{
				filteredPersons = allPersons;
				return filteredPersons;
			}
			
			switch (searchBy)
			{

				case nameof(PersonResponseDTO.PersonName):
					filteredPersons = allPersons.Where(person => (!string.IsNullOrEmpty(person.PersonName)
					&& person.PersonName.Contains(searchString, StringComparison.OrdinalIgnoreCase))).ToList();
					break;

				case nameof(PersonResponseDTO.Email):
					filteredPersons =  allPersons.Where(person=> (!string.IsNullOrEmpty(person.Email)
					&& person.Email.Contains(searchString, StringComparison.OrdinalIgnoreCase))).ToList();	
					break;

				case nameof(PersonResponseDTO.Gender):
					filteredPersons = allPersons.Where(person => (!string.IsNullOrEmpty(person.Gender)
					&& string.Equals((person.Gender).ToLower(), searchString.ToLower()))).ToList();
					break;

				case nameof(PersonResponseDTO.CountryName):
					filteredPersons = allPersons.Where(person => (!string.IsNullOrEmpty(person.CountryName)
					&& person.CountryName.Contains(searchString, StringComparison.OrdinalIgnoreCase))).ToList();
					break;

				default: 
					filteredPersons= allPersons;
					break;
			}

			return filteredPersons;

		}
		public List<PersonResponseDTO> GetSortedPersons(List<PersonResponseDTO> allpersons, string? sortBy , SortOptions? sortOption)
		{
			List<PersonResponseDTO> sortedPersons = new List<PersonResponseDTO>();

			if (string.IsNullOrEmpty(sortBy) ||
				sortOption == null ) {
				sortedPersons= allpersons;	
				return sortedPersons;
			}

			switch(sortBy, sortOption)
			{
				case (nameof(PersonResponseDTO.PersonName), SortOptions.ASC):
					sortedPersons = allpersons.OrderBy(person => person.PersonName).ToList();	
					break;

				case (nameof(PersonResponseDTO.PersonName), SortOptions.DESC):
					sortedPersons = allpersons.OrderByDescending(person => person.PersonName).ToList();
					break;


				case (nameof(PersonResponseDTO.Email), SortOptions.ASC):
					sortedPersons = allpersons.OrderBy(person => person.Email).ToList();
					break;

				case (nameof(PersonResponseDTO.Email), SortOptions.DESC):
					sortedPersons = allpersons.OrderByDescending(person => person.Email).ToList();
					break;


				case (nameof(PersonResponseDTO.Gender), SortOptions.ASC):
					sortedPersons = allpersons.OrderBy(person => person.Gender).ToList();
					break;

				case (nameof(PersonResponseDTO.Gender), SortOptions.DESC):
					sortedPersons = allpersons.OrderByDescending(person => person.Gender).ToList();
					break;


				case (nameof(PersonResponseDTO.CountryName), SortOptions.ASC):
					sortedPersons = allpersons.Where(person=> string.IsNullOrEmpty(person.PersonName))
						                      .OrderBy(person=> person.CountryName).ToList();
					break;

				case (nameof(PersonResponseDTO.CountryName), SortOptions.DESC):
					sortedPersons = allpersons.OrderByDescending(person => person.CountryName).ToList();
					break;

			   default:
					sortedPersons = allpersons; 
					break;
			}

			return sortedPersons;
		}

		public PersonResponseDTO UpdatePerson (PersonUpdateRequestDTO? personUpdateRequestDTO)
		{
			if (personUpdateRequestDTO == null)
			{
				throw new ArgumentNullException(nameof(personUpdateRequestDTO));	
			}

			ValidationResult validationResult = _personUpdateValidaor.Validate(personUpdateRequestDTO);

			bool isValideRequest = validationResult.IsValid; 

			if(!isValideRequest) {
				throw new ArgumentException(nameof(personUpdateRequestDTO)); 
			}




			Guid personID = personUpdateRequestDTO.PersonID;
			PersonEntityModel? personFectched = _personRepository.GetPersonByPersonID(personID);


			string? countryName = personUpdateRequestDTO.CountryName;
			var country = (!string.IsNullOrEmpty(countryName)) ?
			_countryServices.GetCountryByCountryName(countryName):null;

			_personRepository.DeletePerson(personID); // deleate old person if exist 

			PersonEntityModel personToUpdate = PersonRequestsMapper.UpdatePerson(personUpdateRequestDTO, personFectched);

			_personRepository.AddPerson(personToUpdate); // update and add the updated person to the list 

			return PersonResponsesMapper.SendPerson(personToUpdate);	
		}









		public bool DeletePerson(Guid ? personID)
		{
			if (personID == null)
			{
				throw new ArgumentNullException(nameof(personID));	
			}

			 bool isDeleated = _personRepository.DeletePerson(personID);

			if (!isDeleated)
			{
				return false; 
			}

			return true;
		}
	}
}
