using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable
namespace dc_repository.Entities
{
    public class MovimentoRiga : CommonEntities
    {
        [Key]
        public int IdMovimentoRiga { get; set; }
        [ForeignKey("MovimentoRiga")]

        public int MovimentoId { get; set; }

        public Movimento Movimento { get; set; }
        [ForeignKey("ArticoloId")]
        public int ArticoloId { get; set; }

        public Articolo Articolo { get; set; }

        public decimal Prezzo { get; set; }
    }
}
