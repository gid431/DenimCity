using System.ComponentModel.DataAnnotations;
#nullable disable
namespace dc_repository.Entities
{
    public class Tipologia : CommonEntities 
    {
        public Tipologia()
        {
            this.Articoli = new HashSet<Articolo>();
        }
        [Key]
        public int IdTipologia { get; set; }

        public virtual ICollection<Articolo> Articoli { get; set; }

    }
}
