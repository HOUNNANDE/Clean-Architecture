using AspNetCore.Courses.Section15.BusinessLogic.PersonBusinessLogic.DTO;
using AspNetCore.Courses.Section15.BusinessLogic.PersonBusinessLogic.PersonDTO;
using AspNetCore.Courses.Section15.Infrastructures.Infrastructures.ModelsEntities;

namespace AspNetCore.Courses.Section15.BusinessLogic.PersonBusinessLogic.Commons
{
    public static class PersonRequestsMapper
    {
        /// <summary>
        /// this work must be done by AutoMapper or Other third party tool
        /// </summary>
        /// <param name="personRequest"></param>
        /// <returns></returns>
        public static PersonEntityModel BuildPerson(this PersonRequestDTO personRequest)
        {
            var person = new PersonEntityModel()
            {
                PersonID = Guid.NewGuid(),
                PersonName = personRequest.PersonName,
                Email = personRequest.Email,
                DateOfBirth = personRequest.DateOfBirth,
                Gender = personRequest.Gender.ToString(),
                Address = personRequest.Address,   
                ReceiveNewLetters = personRequest.ReceiveNewLetters,
            };
            return person;
        }

        public static PersonEntityModel UpdatePerson(PersonUpdateRequestDTO personUpdateRequest, PersonEntityModel personEntity) {
            
            personEntity.PersonName = personUpdateRequest.PersonName;
            personEntity.Email = personUpdateRequest.Email;
            personEntity.DateOfBirth = personUpdateRequest.DateOfBirth; // search country by name and if not exist call create country service
            personEntity.Address = personUpdateRequest.Address;
            
            // completion of country ID 
            return personEntity;
        }
    }
}
