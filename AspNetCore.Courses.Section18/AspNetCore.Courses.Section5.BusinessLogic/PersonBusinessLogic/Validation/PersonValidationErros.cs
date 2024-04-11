using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results; 

namespace AspNetCore.Courses.Section15.BusinessLogic.PersonBusinessLogic.Validation
{
	public static class PersonValidationErros
	{
		public static ModelStateDictionary AddToModelState(this ValidationResult result, ModelStateDictionary modelState)
		{
			foreach (var error in result.Errors)
			{
				modelState.AddModelError(error.PropertyName, error.ErrorMessage);
			}

			return modelState; // return back the model state to access the erros dictionary 
		}
	}
}
