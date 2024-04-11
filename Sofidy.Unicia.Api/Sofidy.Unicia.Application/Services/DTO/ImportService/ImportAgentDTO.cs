using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofidy.Unicia.Application.Services.DTO.ImportService
{
    public record ImportAgentDTO 
    {
        public string Id { get; set; }
        public string? PartnerCategory { get; set; }
        public string? Title { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public string? Address { get; set; }
        public string? ZipCode { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? AddressAdmin { get; set; }
        public string? ZipCodeAdmin { get; set; }
        public string? CityAdmin { get; set; }
        public string? CountryAdmin { get; set; }
        public string? Siret { get; set; }
        public string? Email { get; set; }
        public string? Tel { get; set; }
        public string? Fax { get; set; }
        public string? IdManager { get; set; }
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
        public string? Iban { get; set; }
        public string? Bic { get; set; }
        public string? Domiciliation { get; set; }
        public string? Holder { get; set; }
    }
}
