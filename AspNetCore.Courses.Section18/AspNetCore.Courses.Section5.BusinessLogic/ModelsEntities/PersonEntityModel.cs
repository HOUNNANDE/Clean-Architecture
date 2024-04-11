using AspNetCore.Courses.Section15.Infrastructures.DAL.DatabaseContexts.CountryDb.Persistence;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.Courses.Section15.Infrastructures.Infrastructures.ModelsEntities
{
    public class PersonEntityModel
    {

        [Key]
        public Guid PersonID { get; set; }

        [StringLength(50)]
        public string? PersonName { get; set; }

        [StringLength(50)]  
        public string? Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
		public string? Gender { get; set; }

        [ForeignKey(nameof(CountryID))]  
        public Guid  CountryID { get; set; } // this navigation is not corrects 
        public CountryEntityModel Country { get; set; } 

        [StringLength(200)]  
        public string? Address { get; set; }
        public bool ReceiveNewLetters { get; set; }
    }
}
