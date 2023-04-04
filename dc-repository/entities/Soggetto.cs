using System.ComponentModel.DataAnnotations;
#nullable disable
namespace dc_repository.Entities
{
    public class Soggetto : LoggerInfo
    {
        [Key]
        public int IdSoggetto { get; set; }
        public TipoSoggetto TipoSoggetto { get; set; }
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [MaxLength(150)]
        public string RagioneSociale { get; set; }

        public string Indirizzo { get; set; }
        [MinLength(11, ErrorMessage = "Il campo è di 11 caratteri")]
        [MaxLength(11, ErrorMessage = "Il campo è di 11 caratteri")]
        public string PartitaIva { get; set; }
        [MinLength(16, ErrorMessage = "Il campo è di 16 caratteri")]
        [MaxLength(16, ErrorMessage = "Il campo è di 16 caratteri")]
        public string CodiceFiscale { get; set; }
        [MaxLength(13)]
        public string NumeroTelefono { get; set; }
        [MaxLength(13)]
        public string Cellulare { get; set; }
        [MaxLength(5)]
        public string Cap { get; set; }

        public string Email { get; set; }
        [Required(ErrorMessage = "Il campo è obbligatorio")]

        public virtual ICollection<Movimento> Movimenti { get; set; }

        public Soggetto()
        {

        }
    }
    public enum TipoSoggetto
    {
        Fornitore,
        Cliente
    }
}
