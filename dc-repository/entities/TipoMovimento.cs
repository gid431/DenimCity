#nullable disable
using System.ComponentModel.DataAnnotations;

namespace dc_repository.Entities
{
    public class TipoMovimento : CommonEntities 
    {
        [Key]
        public int IdMovimento { get; set; }
        public int Segno { get; set; }
        public virtual ICollection<Movimento> Movimenti { get; set; }

        public TipoMovimento()
        {
            this.Movimenti = new HashSet<Movimento>();

        }
    }
}
