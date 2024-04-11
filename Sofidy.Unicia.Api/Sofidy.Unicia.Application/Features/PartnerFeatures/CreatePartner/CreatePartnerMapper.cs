using AutoMapper;
using Sofidy.Unicia.Application.Features.PartnerFeatures.CreatePartner;
using Sofidy.Unicia.Application.Services.DTO.ImportService;
using Sofidy.Unicia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Unicia.Model.Models;

namespace Sofidy.Unicia.Application.Features.PartnerFeatures.CreatePartner
{
    public sealed class CreatePartnerMapper : Profile
    {
        public CreatePartnerMapper()
        {
            CreateMap<CreatePartnerRequest, ImportAgentDTO>().ReverseMap();
        }
    }
}
