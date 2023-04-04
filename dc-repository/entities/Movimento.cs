using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable
namespace dc_repository.Entities
{
    public class Movimento : CommonEntities
    {
        [Key]
        public int IdMovimento { get; set; }

        public DateTime DataMovimento { get; set; }
        [ForeignKey("SoggettoId")]
        public int SoggettoId { get; set; }

        public Soggetto Soggetto { get; set; }

        [ForeignKey("TipoMovimentoId")]
        public int TipoMovimentoId { get; set; }

        public TipoMovimento TipoMovimento { get; set; }

        public decimal TotaleIva { get; set; }

        public decimal Totale { get; set; }

        public TipoPagamento TipoPagamento { get; set; }

        public virtual ICollection<MovimentoRiga> Righe { get; set; }

        public Movimento()
        {
            this.Righe = new HashSet<MovimentoRiga>();
        }
    }

    public enum TipoPagamento
    {
        Contanti,
        Carta,
        Assegno,
        Buono,
        Finanziamento
    }
}
