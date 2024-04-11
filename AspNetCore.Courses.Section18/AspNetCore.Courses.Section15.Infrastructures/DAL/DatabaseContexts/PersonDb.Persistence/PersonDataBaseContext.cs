using AspNetCore.Courses.Section15.Infrastructures.Common;
using AspNetCore.Courses.Section15.Infrastructures.Infrastructures.ModelsEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AspNetCore.Courses.Section15.Infrastructures.DAL.DatabaseContexts.PersonDb.Persistence
{
    public class PersonDataBaseContext : IPersonDbContext
    {
        public List<PersonEntityModel> PersonDbSet
		{
            get
            {
                string fileName = "PersonDataBase.json";
                return DeserializeJsonfile<PersonEntityModel>.DbSet(fileName);
            }
        }
    }



}
