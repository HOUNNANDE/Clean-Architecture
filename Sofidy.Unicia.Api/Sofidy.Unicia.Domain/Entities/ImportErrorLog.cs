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
    [Table("IMPORTERRORLOG")]
    public record ImportErrorLog : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        /// <summary>
        /// Identification de l&apos;enregistrement
        /// </summary>
        public decimal IdImportErrorLog { get; set; }

        /// <summary>
        /// Nom de la table concernée
        /// </summary>
        public string? CTable { get; set; }

        /// <summary>
        /// Nouveau statut - O: Succes ; N : Rejet
        /// </summary>
        public string? FStatutNew { get; set; }

        /// <summary>
        /// Statut de la ligne avant l&apos;import
        /// </summary>
        public string? FStatutOld { get; set; }

        /// <summary>
        /// Code
        /// </summary>
        public string? CCode { get; set; }

        /// <summary>
        /// Identifiant de la ligne d&apos;import de la table concernée (agent, client ou mouvement)
        /// </summary>
        public decimal? IdcTable { get; set; }

        /// <summary>
        /// Description de l&apos;erreur
        /// </summary>
        public string? TMessage { get; set; }

        /// <summary>
        /// Date de l&apos;import
        /// </summary>
        public DateTime? DLog { get; set; }

        /// <summary>
        /// Numéro d&apos;identification du traitement de l&apos;import (agent, client ou mouvement)
        /// </summary>
        public decimal? IdBatch { get; set; }
    }
}
