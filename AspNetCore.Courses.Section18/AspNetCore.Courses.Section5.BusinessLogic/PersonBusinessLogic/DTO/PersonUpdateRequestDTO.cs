﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.Courses.Section15.BusinessLogic.PersonBusinessLogic.DTO
{
	public class PersonUpdateRequestDTO
	{
		public Guid PersonID { get; set; } // find the right person using person ID
		public string? PersonName { get; set; }
		public string? Email { get; set; }
		public DateTime? DateOfBirth { get; set; }
		public string? CountryName { get; set; }
		public string? Address { get; set; }

	}
}
