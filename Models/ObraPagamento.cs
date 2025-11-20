using System.ComponentModel.DataAnnotations;

namespace GestaoObras.Models
{
    public class ObraPagamento
    {
        public int Id { get; set; }

        // FK
        public int ObraId { get; set; }
        public Obra? Obra { get; set; }

        [Required(ErrorMessage = "O nome da pessoa é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome não pode ter mais de 100 caracteres.")]
        public string Pessoa { get; set; } = string.Empty;

        [Required(ErrorMessage = "O valor é obrigatório.")]
        [Range(0.01, 1000000, ErrorMessage = "O valor deve ser superior a zero.")]
        public decimal Valor { get; set; }

        [Display(Name = "Data do Pagamento")]
        public DateTime DataHora { get; set; } = DateTime.UtcNow;
    }
}
