using AspNetCore.Courses.Section15.Infrastructures.Infrastructures.ModelsEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.Courses.Section15.Infrastructures.DAL.Repositories.Interfaces
{
	public interface IPersonRepository
	{
		public PersonEntityModel AddPerson(PersonEntityModel ? person);
		public List<PersonEntityModel> GetAllPersons();
		public PersonEntityModel GetPersonByPersonID(Guid? personID);

		public PersonEntityModel UpdatePerson(PersonEntityModel? person);

		public bool DeletePerson(Guid? personID);

  

    }
}
