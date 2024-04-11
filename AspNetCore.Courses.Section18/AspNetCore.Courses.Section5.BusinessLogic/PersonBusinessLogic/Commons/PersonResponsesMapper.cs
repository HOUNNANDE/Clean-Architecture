using AspNetCore.Courses.Section15.BusinessLogic.PersonBusinessLogic.BusinessCalculation;
using AspNetCore.Courses.Section15.BusinessLogic.PersonBusinessLogic.PersonDTO;
using AspNetCore.Courses.Section15.Infrastructures.Infrastructures.ModelsEntities;

namespace AspNetCore.Courses.Section15.BusinessLogic.PersonBusinessLogic.Commons
{
    public static class PersonResponsesMapper
    {

        public static PersonResponseDTO SendPerson(this PersonEntityModel personEntityModel)
        {
            var personResponseDTO = new PersonResponseDTO()
            {
                PersonID = personEntityModel.PersonID,
                PersonName = personEntityModel.PersonName,
                Email = personEntityModel.Email,
                DateOfBirth = personEntityModel.DateOfBirth,
                Gender = personEntityModel.Gender,
                CountryID = personEntityModel.CountryID,
                Address = personEntityModel.Address,
                ReceiveNewLetters = personEntityModel.ReceiveNewLetters,
                Age = (personEntityModel.DateOfBirth != null) ? Math.Round((DateTime.Now - personEntityModel.DateOfBirth.Value).TotalDays / 365.25) : null
            };
            
           return personResponseDTO;
		
        }
            
        
    }
}
