using AspNetCore.Courses.Section15.BusinessLogic.CountryBusinessLogic.CountryServices;
using AspNetCore.Courses.Section15.BusinessLogic.CountryBusinessLogic.DTO;
using AspNetCore.Courses.Section15.BusinessLogic.CountryBusinessLogic.PersonServices;
using AspNetCore.Courses.Section15.BusinessLogic.PersonBusinessLogic.Enum;
using AspNetCore.Courses.Section15.BusinessLogic.PersonBusinessLogic.PersonDTO;
using AspNetCore.Courses.Section15.BusinessLogic.PersonBusinessLogic.Validation;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;


namespace AspNetCore.Courses.Section15.Controllers
{

	[Route("persons")]
	public class PersonsController : Controller
	{
		private readonly IPersonServices _personServices;
		private readonly ICountryServices _countryServices;
		private readonly IValidator<PersonRequestDTO> _personRequestValidator;

		public PersonsController(IPersonServices personServices, ICountryServices countryService, IValidator<PersonRequestDTO> personRequestValidator)
		{
			_personServices = personServices;
			_countryServices = countryService;
			_personRequestValidator = personRequestValidator;	
		}

		[HttpGet]
		[Route("index")]
		[Route("/")]
		public IActionResult Index(string? searchBy, string? searchString,
			string? sortBy = nameof(PersonRequestDTO.PersonName), SortOptions sortOption = SortOptions.ASC
			)
		{
			var allPersons = _personServices.GetFilteredPersons(searchBy, searchString);
			var SortedPersons = _personServices.GetSortedPersons(allPersons, sortBy, sortOption);


			ViewBag.InputsOptions = new Dictionary<string, string>() {
				{
					nameof(PersonResponseDTO.PersonName), "Person Name"
				},
				{
					nameof(PersonResponseDTO.Email), "Email"
				},

				{
					nameof(PersonResponseDTO.Gender), "Gender"
				},

				{
					nameof(PersonResponseDTO.CountryName), "CountryName"
				},

			};

			ViewBag.CurrentSearchBy = searchBy;
			ViewBag.CurrentSearchString = searchString; 
			ViewBag.SortBy = sortBy;
			ViewBag.SortOption = sortOption;	
			return View(SortedPersons);
		}


		[HttpGet]
		[Route("create")]
		public IActionResult Create()
		{
			List<CountryResponseDTO> countries = _countryServices.GetAllCountries();
			ViewBag.Countries = countries;	
			return View();	
		}


		[HttpPost]
		[Route("create")]
		public IActionResult Create(PersonRequestDTO personRequestDTO)
		{
			ValidationResult personValidationResult = _personRequestValidator.Validate(personRequestDTO);

			if (!personValidationResult.IsValid)
			{
				List<CountryResponseDTO> countries = _countryServices.GetAllCountries();
				ViewBag.Countries = countries;
				// Copy the validation results into ModelState.
				// ASP.NET uses the ModelState collection to populate 
				// error messages in the View.
				personValidationResult.AddToModelState(this.ModelState);

				// re-render the view when validation failed.
				return View();
			}

			PersonResponseDTO personResponse = _personServices.AddPerson(personRequestDTO); 

			return RedirectToAction("Index");
		}
	}
}
