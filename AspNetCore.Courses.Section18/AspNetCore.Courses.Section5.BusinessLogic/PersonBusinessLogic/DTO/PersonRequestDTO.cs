using AspNetCore.Courses.Section15.BusinessLogic.PersonBusinessLogic.Enum;

namespace AspNetCore.Courses.Section15.BusinessLogic.PersonBusinessLogic.PersonDTO
{
    /// <summary>
    /// Handle person request from the browser
    /// transfert person request to be stored in the data base 
    /// </summary>
    public class PersonRequestDTO
    {
        public string? PersonName { get; set; }
        public string? Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public GenderOptions Gender { get; set; }
        public string ? CountryName { get; set; }
        public string? Address { get; set; }
        public bool ReceiveNewLetters { get; set; }
	}
}
