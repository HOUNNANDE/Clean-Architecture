using AutoMapper;
using Sofidy.Unicia.Application.Features.PartnerFeatures.CreatePartner;
using Sofidy.Unicia.Domain.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicia.Model.Models;

namespace Sofidy.Unicia.Application.Services.DTO.ImportService
{
    public sealed class ImportServiceMapper : Profile
    {
        public ImportServiceMapper()
        {
            MapPartner();
            MapImportStatut();
        }

        private void MapPartner()
        {
            CreateMap<ImportAgentDTO ,ImportAgent>()
                .ForMember(dest => dest.IDAgent, opt => opt.MapFrom(s => s.Id))
                .ForMember(dest => dest.CTypes, opt => opt.MapFrom(s => s.PartnerCategory))
                .ForMember(dest => dest.CTitre, opt => opt.MapFrom(s => s.Title))
                .ForMember(dest => dest.TNom, opt => opt.MapFrom(s => s.LastName))
                .ForMember(dest => dest.TPrenom, opt => opt.MapFrom(s => s.FirstName))
                .ForMember(dest => dest.TAdd1Domicile, opt => opt.MapFrom(s => s.Address))
                .ForMember(dest => dest.TCpDomicile, opt => opt.MapFrom(s => s.ZipCode)) 
                .ForMember(dest => dest.TPaysDomicile, opt => opt.MapFrom(s => s.City))
                .ForMember(dest => dest.TPaysDomicile, opt => opt.MapFrom(s => s.Country))
                .ForMember(dest => dest.TAdd1Domicile, opt => opt.MapFrom(s => s.AddressAdmin))
                .ForMember(dest => dest.TCpDomicile, opt => opt.MapFrom(s => s.ZipCodeAdmin))
                .ForMember(dest => dest.TPaysDomicile, opt => opt.MapFrom(s => s.CityAdmin))
                .ForMember(dest => dest.TPaysDomicile, opt => opt.MapFrom(s => s.CountryAdmin))
                .ForMember(dest => dest.TSiret, opt => opt.MapFrom(s => s.Siret))
                .ForMember(dest => dest.TEmail, opt => opt.MapFrom(s => s.Email))
                .ForMember(dest => dest.TTel, opt => opt.MapFrom(s => s.Tel))
                .ForMember(dest => dest.TFax, opt => opt.MapFrom(s => s.Fax))
                .ForMember(dest => dest.IdManager, opt => opt.MapFrom(s => s.IdManager)) 
                .ForMember(dest => dest.DDeb, opt => opt.MapFrom(s => s.StartDate)) 
                .ForMember(dest => dest.DFin, opt => opt.MapFrom(s => s.EndDate))
                .ForMember(dest => dest.CIban, opt => opt.MapFrom(s => s.Iban))
                .ForMember(dest => dest.CBic, opt => opt.MapFrom(s => s.Bic))
                .ForMember(dest => dest.TDom, opt => opt.MapFrom(s => s.Domiciliation))
                .ForMember(dest => dest.TTitulaire, opt=> opt.MapFrom(s => s.Holder))
                .ReverseMap();
        }

        private void MapImportStatut()
        {
            CreateMap<BaseImportEntity, ImportStatusDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(dest => dest.IdBatch, opt => opt.MapFrom(s => s.IdBatch))
                .ForMember(dest => dest.CStatut, opt => opt.MapFrom(s => s.CStatut));
        }
    }
}
