using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.Courses.Section15.BusinessLogic.PersonBusinessLogic.BusinessCalculation
{
    public interface IPersonBusinessCalculation
    {
		double? GetPersonAge(DateTime? dateOfBirth);
	}
}
