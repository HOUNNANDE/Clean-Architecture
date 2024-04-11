using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.Courses.Section15.BusinessLogic.CountryBusinessLogic.DTO
{
    /// <summary>
    /// data transfert object to accept request from browser
    /// call by Accept rquest to create an object of type country 
    /// </summary>
    public class CountryRequestDTO
    {
        public string? CountryName { get; set; }
        public bool ReceiveNewLetters { get; internal set; }
    }
}
