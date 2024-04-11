using AspNetCore.Courses.Section15.BusinessLogic.CountryBusinessLogic.CountryServices;
using AspNetCore.Courses.Section15.BusinessLogic.CountryBusinessLogic.DTO;
using AspNetCore.Courses.Section15.BusinessLogic.CountryBusinessLogic.PersonServices;
using AspNetCore.Courses.Section15.BusinessLogic.CountryBusinessLogic.Validation;
using AspNetCore.Courses.Section15.BusinessLogic.PersonBusinessLogic.BusinessCalculation;
using AspNetCore.Courses.Section15.BusinessLogic.PersonBusinessLogic.Commons;
using AspNetCore.Courses.Section15.BusinessLogic.PersonBusinessLogic.DTO;
using AspNetCore.Courses.Section15.BusinessLogic.PersonBusinessLogic.PersonDTO;
using AspNetCore.Courses.Section15.BusinessLogic.PersonBusinessLogic.Validation;
using AspNetCore.Courses.Section15.Infrastructures.DAL.DatabaseContexts;
using AspNetCore.Courses.Section15.Infrastructures.DAL.DatabaseContexts.CountryDb.Persistence;
using AspNetCore.Courses.Section15.Infrastructures.DAL.DatabaseContexts.PersonDb.Persistence;
using AspNetCore.Courses.Section15.Infrastructures.DAL.Repositories;
using AspNetCore.Courses.Section15.Infrastructures.DAL.Repositories.Interfaces;
using FluentValidation;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

#region Services Configuration

// Add services to the container. Separeate services in service extension to symplifie the configuration 
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();
builder.Services.AddControllers();
builder.Services.AddScoped<IValidator<PersonRequestDTO>, PersonValidation>();
builder.Services.AddScoped<IValidator<PersonUpdateRequestDTO>, UpdatePersonValidation>();
builder.Services.AddScoped<IValidator<CountryRequestDTO>, CountryValidation>(); 
builder.Services.AddScoped<IPersonDbContext, PersonDataBaseContext>();
builder.Services.AddScoped<ICountryDbContext, CountryDataBaseContext>();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<ICountryServices, CountryServices>();
builder.Services.AddScoped<IPersonServices, PersonServices>();
builder.Services.AddScoped<IPersonBusinessCalculation, PersonBusinessCalculation>();

builder.Services.AddDbContext<PersonsDbContext>(options =>
{
	var connectionString = builder.Configuration.GetConnectionString("ConnectionKey");
	if (!string.IsNullOrEmpty(connectionString))
	{
		options.UseSqlServer(connectionString);
	}
});

#endregion


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.MapControllers();	

app.Run();
