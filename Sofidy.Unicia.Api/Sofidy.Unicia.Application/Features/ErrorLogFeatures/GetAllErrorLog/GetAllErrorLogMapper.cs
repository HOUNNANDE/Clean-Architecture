using AutoMapper;
using Sofidy.Unicia.Application.Services.DTO.ImportService;
using Sofidy.Unicia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Unicia.Model.Models;

namespace Sofidy.Unicia.Application.Features.ErrorLogFeatures.GetAllErrorLog
{
    public sealed class GetAllErrorLogMapper : Profile
    {
        public GetAllErrorLogMapper()
        {
            CreateMap<ImportErrorLog, GetAllErrorLogResponse>().ReverseMap();
        }
    }
}
