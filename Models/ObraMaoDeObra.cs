using System.ComponentModel.DataAnnotations;

namespace GestaoObras.Models
{
    public class ObraMaoDeObra
    {
        public int Id { get; set; }

        // FK para Obra
        public int ObraId { get; set; }
        public Obra? Obra { get; set; }

        [Required(ErrorMessage = "O nome da pessoa é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome não pode ter mais de 100 caracteres.")]
        public string Pessoa { get; set; } = string.Empty;

        [Required(ErrorMessage = "O número de horas é obrigatório.")]
        [Range(0.1, 1000, ErrorMessage = "As horas trabalhadas devem ser superiores a zero.")]
        [Display(Name = "Horas Trabalhadas")]
        public double HorasTrabalhadas { get; set; }

        [Display(Name = "Data do Registo")]
        public DateTime DataHora { get; set; } = DateTime.UtcNow;
    }
}

