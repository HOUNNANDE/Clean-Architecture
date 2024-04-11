using Microsoft.EntityFrameworkCore;
using Sofidy.Unicia.Domain.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofidy.Unicia.Domain.Entities
{
    [PrimaryKey(nameof(ITyparam), nameof(IClient))]
    [Table("ICONVERT")]
    public record IConvert : BaseEntity
    { 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        /// <summary>
        /// Entité concernée (1=Client, 2=Agent, 3=Adresses et RIB, 4=Mouvements, 5=Entrées, 6=Sorties, 7=Transferts)
        /// </summary>
        public decimal ITyparam { get; set; }
         
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        /// <summary>
        /// Code client
        /// </summary>
        public string IClient { get; set; } = null!;

        /// <summary>
        /// Code correspondance 1
        /// </summary>
        public string? ICorresp1 { get; set; }

        /// <summary>
        /// Code correspondance 2
        /// </summary>
        public string? ICorresp2 { get; set; }

        /// <summary>
        /// Code correspondance 3
        /// </summary>
        public string? ICorresp3 { get; set; }
    }
}
