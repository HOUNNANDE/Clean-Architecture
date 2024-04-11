using AspNetCore.Courses.Section15.Infrastructures.DAL.DatabaseContexts.PersonDb.Persistence;
using AspNetCore.Courses.Section15.Infrastructures.DAL.Repositories.Interfaces;
using AspNetCore.Courses.Section15.Infrastructures.DAL.DatabaseContexts;
using AspNetCore.Courses.Section15.Infrastructures.Infrastructures.ModelsEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace AspNetCore.Courses.Section15.Infrastructures.DAL.Repositories
{
    public class PersonRepository : IPersonRepository
	{
		private readonly PersonsDbContext _dbContext;
		public PersonRepository(PersonsDbContext dbContext) {
			_dbContext = dbContext;
		}	

		public PersonEntityModel AddPerson(PersonEntityModel? person)
		{
			_dbContext.PersonsDbSet.Add(person);

			_dbContext.SaveChanges();
			
			return person;	
		}



		public bool DeletePerson(Guid? personID)
		{
			var person = _dbContext.PersonsDbSet.Where(person => person.PersonID == personID).FirstOrDefault(); 
			
			if (person == null)
			{
				throw new Exception($"{nameof(person)} the person to be deleated is not found"); 
			}

			_dbContext.PersonsDbSet.Remove(person); 

			if(_dbContext.PersonsDbSet.Where(person => person.PersonID == personID).Count() > 0)
			{
				return false; 
			}
            _dbContext.SaveChanges();
            return true;
		}

		public List<PersonEntityModel> GetAllPersons()
		{
			var persons = _dbContext.PersonsDbSet.ToList(); 
			
			if(!persons.Any()) {
				throw new Exception($"{nameof(persons)} the persons data base is empty");
			}

			return persons; 
		}

		public PersonEntityModel GetPersonByPersonID(Guid? personID)
		{
			var person = _dbContext.PersonsDbSet.Where(person => person.PersonID == personID).FirstOrDefault();

			if (person == null)
			{
				throw new Exception($"{nameof(person)} the person fetched does'nt exist");
			}

			return person;
		}
		public PersonEntityModel UpdatePerson(PersonEntityModel? person)
		{
			_dbContext.PersonsDbSet.Add(person);
			_dbContext.SaveChanges();	

			return person;
		}
	}
}
