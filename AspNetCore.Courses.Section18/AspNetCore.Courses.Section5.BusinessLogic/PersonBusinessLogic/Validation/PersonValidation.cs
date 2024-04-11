using AspNetCore.Courses.Section15.BusinessLogic.PersonBusinessLogic.Enum;
using AspNetCore.Courses.Section15.BusinessLogic.PersonBusinessLogic.PersonDTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.Courses.Section15.BusinessLogic.PersonBusinessLogic.Validation
{
	public class PersonValidation : AbstractValidator<PersonRequestDTO>
	{
		public PersonValidation() {
			RuleFor(personRequest => personRequest.PersonName).NotEmpty();
			RuleFor(personRequest=> personRequest.Email)
				.NotNull()
			    .NotEmpty()		
	            .EmailAddress();

			RuleFor(personRequest => personRequest.DateOfBirth).NotNull();
			RuleFor(personRequest => personRequest.Gender).IsInEnum();

		}	
	}
}
