using AutoMapper;
using MediatR;
using Sofidy.Unicia.Application.Features.ErrorLogFeatures.GetAllErrorLog;
using Sofidy.Unicia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicia.Model.Models;

namespace Sofidy.Unicia.Application.Features.MetadataFeatures.GetAllPImport
{
    public class GetAllPImportMapper : Profile
    {
        public GetAllPImportMapper()
        {
            CreateMap<PImport, GetAllPImportResponse>() 
                .ForMember(dest => dest.IClient, opt => opt.MapFrom(s => s.IClient.Trim()))
                .ReverseMap();
        }
    }
}
