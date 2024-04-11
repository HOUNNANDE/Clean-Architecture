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
    [Table("ACKCACHE")]
    public record AckCache : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid IdAckCache { get; set; } 
        
        public string IdClient { get; set; }
        /// <summary>
        /// Timestamp
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime DCreated { get; set; }
        /// <summary>
        /// Id of metatype ( ImportAgent , ImportClient) 
        /// </summary>
        public decimal IdImport { get; set; }
        /// <summary>
        /// Metatype ( ImportAgent , ImportClient )
        /// </summary>
        public string CTypes { get; set; }

        /// <summary>
        /// CChannel 
        /// </summary>
        public string CChannel { get; set; }

        /// <summary>
        /// Already acked
        /// </summary>
        public bool FAcked { get; set; } = false; 
    }
}
