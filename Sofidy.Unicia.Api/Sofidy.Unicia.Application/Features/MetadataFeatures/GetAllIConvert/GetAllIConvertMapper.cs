using AutoMapper;
using MediatR;
using Sofidy.Unicia.Application.Features.ErrorLogFeatures.GetAllErrorLog;
using Sofidy.Unicia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofidy.Unicia.Application.Features.MetadataFeatures.GetAllIConvert
{
    public class GetAllIConvertMapper : Profile
    {
        public GetAllIConvertMapper()
        {
            CreateMap<IConvert, GetAllIConvertResponse>()
                .ForMember(dest => dest.IClient, opt => opt.MapFrom(s => s.IClient.Trim()))
                .ReverseMap();
        }
    }
}
