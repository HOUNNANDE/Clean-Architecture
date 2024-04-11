using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofidy.Unicia.Application.Services.DTO.AckCacheService
{
    public record AckCacheDTO
    {
        public string IdClient { get; set; }
        public decimal IdImport { get; set; }
        public string Type { get; set; }
        public string Channel { get; set; }
    }
}
