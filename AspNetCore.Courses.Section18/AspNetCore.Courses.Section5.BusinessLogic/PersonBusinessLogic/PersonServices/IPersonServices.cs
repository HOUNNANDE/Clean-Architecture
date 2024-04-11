using AspNetCore.Courses.Section15.BusinessLogic.CountryBusinessLogic.DTO;
using AspNetCore.Courses.Section15.BusinessLogic.PersonBusinessLogic.DTO;
using AspNetCore.Courses.Section15.BusinessLogic.PersonBusinessLogic.Enum;
using AspNetCore.Courses.Section15.BusinessLogic.PersonBusinessLogic.PersonDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.Courses.Section15.BusinessLogic.CountryBusinessLogic.PersonServices
{
    public interface IPersonServices
	{
		public	PersonResponseDTO AddPerson(PersonRequestDTO? personRequestDTO);
		public List<PersonResponseDTO> GetAllPersons();
		public PersonResponseDTO GetPersonByPersonID(Guid? personID);

		public List<PersonResponseDTO> GetFilteredPersons(string? searchBy, string? searchString);

		public List<PersonResponseDTO> GetSortedPersons(List<PersonResponseDTO> allpersons, string ? sortBy, SortOptions ? sortOrder);

		public PersonResponseDTO UpdatePerson(PersonUpdateRequestDTO ? personRequestDTO);

		public bool DeletePerson(Guid? personID);

	}
}
