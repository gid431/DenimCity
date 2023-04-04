using System.ComponentModel.DataAnnotations;
#nullable disable
namespace dc_repository.Entities
{
    public class Categoria : CommonEntities

    {
        public Categoria()
        {
            this.Articoli = new HashSet<Articolo>();
        }
        [Key]
        public int IdCategoria { get; set; }
        public virtual ICollection<Articolo> Articoli { get; set; }

    }
}
