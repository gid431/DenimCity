using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable
namespace dc_repository.Entities
{
    /// <summary>
    /// Entità articolo
    /// </summary>
    public class Articolo : LoggerInfo
    {
        /// <summary>
        /// chiave primaria di tipo intero 
        /// </summary>
        [Key]
        public int IdArticolo { get; set; }

        /// <summary>
        /// proprietà stringa codice prodotto
        /// </summary>
        
        [MaxLength(20, ErrorMessage = "Il campo codice prodotto ammette massimo 20 caratteri")]
        [MinLength(3, ErrorMessage = "Il campo codice prodotto ammette minimo 3 caratteri")]
        [Required(ErrorMessage = "Il campo codice prodotto è obbligatorio")]
        public string CodiceProdotto { get; set; }

        /// <summary>
        /// proprietà stinga descrizione prodotto
        /// </summary>
        
        [MaxLength(500)]
        public string Descrizione { get; set; }

        public decimal PrezzoAcquisto { get; set; }

        public decimal Giancenza { get; set; }

        public decimal PrezzoVendita { get; set; }
        [MaxLength(200)]
        public string UrlImmagine { get; set; }
        [MaxLength(13)]
        public string CodiceABarre { get; set; }

        public Gender Sesso { get; set; }
        [ForeignKey("TipologiaId")]
        public int TipologiaId { get; set; }

        public Tipologia Tipologia { get; set; }
        [ForeignKey("CategoriaId")]

        public int CategoriaId { get; set; }

        public Categoria Categoria { get; set; }
        [ForeignKey("MarchioId")]

        public int MarchioId { get; set; }
        public Marchio Marchio { get; set; }
        public virtual ICollection<MovimentoRiga> Righe { get; set; }
        public Articolo()
        {
            this.Righe = new HashSet<MovimentoRiga>();
        }
    }

    public enum Gender
    {
        Maschio,
        Femmina,
        Altro
    }

}

