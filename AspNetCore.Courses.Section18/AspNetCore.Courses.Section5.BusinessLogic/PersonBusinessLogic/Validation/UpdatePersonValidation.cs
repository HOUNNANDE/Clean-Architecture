using AspNetCore.Courses.Section15.BusinessLogic.PersonBusinessLogic.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.Courses.Section15.BusinessLogic.PersonBusinessLogic.Validation
{
	public class UpdatePersonValidation : AbstractValidator<PersonUpdateRequestDTO>
	{
		public UpdatePersonValidation() {
			RuleFor(updateRequest => updateRequest.Email).EmailAddress();
			RuleFor(updateRequest => updateRequest.CountryName).NotNull().NotEmpty(); 
			RuleFor(updateRequest=> updateRequest.PersonName).NotNull().NotEmpty();
			RuleFor(updateRequest => updateRequest.DateOfBirth).NotNull(); 
		}
	}
}
