using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofidy.Unicia.Application.Features.PartnerFeatures.CreatePartner
{
    public sealed class CreatePartnerValidator : AbstractValidator<CreatePartnerRequest>
    {
        public CreatePartnerValidator()
        {
            RuleFor(x => x.Id).NotNull();
        }
    }
}
