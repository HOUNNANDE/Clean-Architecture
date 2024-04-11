namespace AspNetCore.Courses.Section15.BusinessLogic.PersonBusinessLogic.PersonDTO
{

    /// <summary>
    /// Handle person request from the browser
    /// transfert person request from the data base to the controler / browser
    /// </summary>
    public class PersonResponseDTO
    {
        public Guid PersonID { get; set; }
        public string? PersonName { get; set; }
        public string? Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public Guid? CountryID { get; set; }
        public string? CountryName { get; set; }
        public string? Address { get; set; }

        public bool ReceiveNewLetters { get; set; }
        public double? Age { get; set; }  


        public override bool Equals(object? obj)
        {
            if (obj == null) { return false; }
            if (obj.GetType() != typeof(PersonResponseDTO))
            { return false; }
            var OtherPerson = (PersonResponseDTO)obj;

            bool query = PersonID == OtherPerson.PersonID
                         & PersonName == OtherPerson.PersonName
                         & Email == OtherPerson.Email
                         & Gender == OtherPerson.Gender
                         & CountryID == OtherPerson.CountryID
                         & Address == OtherPerson.Address
                         & ReceiveNewLetters == OtherPerson.ReceiveNewLetters;
            return query;
        }



        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }


}
