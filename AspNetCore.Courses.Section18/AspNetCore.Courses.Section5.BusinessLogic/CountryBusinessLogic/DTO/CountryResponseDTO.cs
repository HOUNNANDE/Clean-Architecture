using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.Courses.Section15.BusinessLogic.CountryBusinessLogic.DTO
{

    /// <summary>
    /// data transfert object to send country object to the browser 
    /// call by Send Country class to send country object to the browser
    /// </summary>
    public class CountryResponseDTO
    {
        public Guid CountryID { get; set; }
        public string? CountryName { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj == null ||
                obj.GetType() != typeof(CountryResponseDTO))
            {
                return false;
            }

            var otherObj = (CountryResponseDTO)obj;

            bool compareQuery = otherObj.CountryID == CountryID
                & otherObj.CountryName == CountryName;
            return compareQuery;
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

	
	}





}
