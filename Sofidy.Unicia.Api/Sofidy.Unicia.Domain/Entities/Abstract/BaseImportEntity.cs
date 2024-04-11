using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofidy.Unicia.Domain.Entities.Abstract
{
    public abstract record BaseImportEntity : BaseEntity
    {
        /// <summary>
        /// Statut de traitement : N pour Nouveau, M pour Modifié. Valeurs de retour : S pour Succès, R pour Rejet.
        /// </summary>
        public string? CStatut { get; set; }

        /// <summary>
        /// Numéro d&apos;identification du traitement de l&apos;import du client
        /// </summary>
        public decimal? IdBatch { get; set; }


        public abstract decimal Id { get; }
    }
}
