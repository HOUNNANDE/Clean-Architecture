using AutoMapper;
using Sofidy.Unicia.Application.Features.PartnerFeatures.CreatePartner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicia.Model.Models;
using Sofidy.Unicia.Application.Services.DTO.AckCacheService;
using Sofidy.Unicia.Domain.Entities;

namespace Sofidy.Unicia.Application.Services.DTO.ImportService
{
    public sealed class AckCacheServiceMapper : Profile
    {
        public AckCacheServiceMapper()
        {
            CreateMap<AckCache, AckCacheDTO>()
                .ForMember(dest => dest.IdClient, opt => opt.MapFrom(s => s.IdClient))
                .ForMember(dest => dest.IdImport, opt => opt.MapFrom(s => s.IdImport))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(s => s.CTypes))
                .ForMember(dest => dest.Channel, opt => opt.MapFrom(s => s.CChannel))
                .ReverseMap();

            MapPartner(); 
        }

        private void MapPartner()
        {
            CreateMap<ImportAgentDTO, AckCacheDTO>()
                .ForMember(dest => dest.IdClient, opt => opt.MapFrom(s => s.Id))  
                .ReverseMap();
        } 
    }
}
