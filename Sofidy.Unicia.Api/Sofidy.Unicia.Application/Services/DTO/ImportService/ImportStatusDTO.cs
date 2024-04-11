using Sofidy.Unicia.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofidy.Unicia.Application.Services.DTO.ImportService
{
    public record ImportStatusDTO
    {
        public ImportStatus Status
        {
            get
            {
                switch (this.CStatut)
                {
                    case "S":
                        return ImportStatus.OK;
                    case "R":
                        return ImportStatus.KO;
                    default:
                        return ImportStatus.None;
                } 
            }
        }
        public decimal Id { get; set; }
        public string? CStatut { get; set; }  
        public decimal? IdBatch { get; set; }
    } 
}
