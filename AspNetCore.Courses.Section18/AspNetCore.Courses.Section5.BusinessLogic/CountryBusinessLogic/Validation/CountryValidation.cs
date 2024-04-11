using AspNetCore.Courses.Section15.BusinessLogic.CountryBusinessLogic.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.Courses.Section15.BusinessLogic.CountryBusinessLogic.Validation
{
	public class CountryValidation : AbstractValidator<CountryRequestDTO>
	{
		public CountryValidation() {
			RuleFor(country=> country.CountryName).NotNull()
           	                                      .NotEmpty();	
		}	
	}
}
