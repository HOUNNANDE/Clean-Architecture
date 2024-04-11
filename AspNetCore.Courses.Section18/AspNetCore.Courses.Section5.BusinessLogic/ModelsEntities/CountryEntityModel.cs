using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; 

namespace AspNetCore.Courses.Section15.Infrastructures.Infrastructures.ModelsEntities
{
    public class CountryEntityModel
    {

        [Key]
        public Guid CountryID { get; set; }
        [StringLength(100)]
        public string? CountryName { get; set; }

    }
}
