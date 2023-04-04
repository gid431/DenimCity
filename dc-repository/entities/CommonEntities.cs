using System.ComponentModel.DataAnnotations;

#nullable disable

namespace dc_repository.Entities
{

    public class CommonEntities : LoggerInfo //non è tabella dati
    {
        [MaxLength(50, ErrorMessage = "Il campo categoria ammette massimo 500 caratteri")]
        [MinLength(3, ErrorMessage = "Il campo categoria ammette minimo 3 caratteri")]
        [Required(ErrorMessage = "Il campo categoria è obbligatorio")]
        public string Descrizione { get; set; }
    }
    public class LoggerInfo
    {
        public DateTime DataDiCreazione { get; set; }
        public DateTime DataAggiornamento { get; set; }

        public string Operatore { get; set; }
    }
}
