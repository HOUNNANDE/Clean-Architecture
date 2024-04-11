using AspNetCore.Courses.Section15.Infrastructures.Common;
using AspNetCore.Courses.Section15.Infrastructures.DAL.DatabaseContexts.CountryDb.Persistence;
using AspNetCore.Courses.Section15.Infrastructures.DAL.DatabaseContexts.PersonDb.Persistence;
using AspNetCore.Courses.Section15.Infrastructures.Infrastructures.ModelsEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.Courses.Section15.Infrastructures.DAL.DatabaseContexts
{
	public class PersonsDbContext: DbContext 
	{

		public DbSet<PersonEntityModel> PersonsDbSet { get; set; }	
		public DbSet<CountryEntityModel> CountriesDbSet { get; set; }
	    public PersonsDbContext(DbContextOptions<PersonsDbContext> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// table mapping 
			modelBuilder.Entity<PersonEntityModel>()
						.ToTable("Persons");

			modelBuilder.Entity<CountryEntityModel>().ToTable("Countries");

			// Add seed data to the table ; 
			string countriesJsonfile = "CountryDataBase.json";
		    var countries  =  DeserializeJsonfile<CountryEntityModel>.DbSet(countriesJsonfile);

			string personsJsonfile = "PersonDataBase.json";
			var persons =  DeserializeJsonfile<PersonEntityModel>.DbSet(personsJsonfile);

			foreach(PersonEntityModel person in persons)
			{
				modelBuilder.Entity<PersonEntityModel>().HasData(person);
			}

			foreach (CountryEntityModel country in countries)
			{
				modelBuilder.Entity<CountryEntityModel>().HasData(country);
			}

		}
	}
}
