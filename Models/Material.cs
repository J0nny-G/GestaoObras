using System.ComponentModel.DataAnnotations;

namespace GestaoObras.Models
{
    public class Material
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do material é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome não pode ter mais de 100 caracteres.")]
        public string Nome { get; set; } = string.Empty;

        [StringLength(300, ErrorMessage = "A descrição não pode ter mais de 300 caracteres.")]
        public string? Descricao { get; set; }

        [Required(ErrorMessage = "O stock disponível é obrigatório.")]
        [Range(0, 999999, ErrorMessage = "O stock deve ser um número positivo.")]
        [Display(Name = "Stock Disponível")]
        public int StockDisponivel { get; set; }

        // Relações N:N e movimentos
        public ICollection<ObraMaterial>? Obras { get; set; }
        public ICollection<MovimentoStock>? Movimentos { get; set; }
    }
}
