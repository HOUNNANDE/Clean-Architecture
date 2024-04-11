using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.Courses.Section15.BusinessLogic.PersonBusinessLogic.BusinessCalculation
{
	public class PersonBusinessCalculation : IPersonBusinessCalculation
	{
		public PersonBusinessCalculation() {
		}
		public double ? GetPersonAge(DateTime ? dateOfBirth)
		{
			var dateNow = DateTime.Now;	
			if(dateOfBirth > dateNow)
			{
				throw new Exception(); 
			}

			if (dateOfBirth == null)
			{
				throw new Exception();
			}

			var age = (dateNow - dateOfBirth.Value).TotalDays / 365.25;

			return age; 


		}


	}
}
