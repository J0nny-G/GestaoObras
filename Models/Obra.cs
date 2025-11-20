using System.ComponentModel.DataAnnotations;

namespace GestaoObras.Models
{
    public class Obra
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome da obra é obrigatório.")]
        [StringLength(150, ErrorMessage = "O nome não pode ter mais de 150 caracteres.")]
        public string Nome { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "A descrição não pode ter mais de 500 caracteres.")]
        public string? Descricao { get; set; }

        [Required(ErrorMessage = "A morada é obrigatória.")]
        [StringLength(200, ErrorMessage = "A morada não pode ter mais de 200 caracteres.")]
        public string? Morada { get; set; }

        [Range(-90, 90, ErrorMessage = "A latitude deve estar entre -90 e 90.")]
        public double? Latitude { get; set; }

        [Range(-180, 180, ErrorMessage = "A longitude deve estar entre -180 e 180.")]
        public double? Longitude { get; set; }

        [Display(Name = "Obra Ativa")]
        public bool Ativa { get; set; } = true;

        // FK Cliente
        [Required(ErrorMessage = "É necessário selecionar um cliente.")]
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }

        // Relações
        public ICollection<ObraMaterial> Materiais { get; set; } = new List<ObraMaterial>();
        public ICollection<ObraMaoDeObra> MaoDeObra { get; set; } = new List<ObraMaoDeObra>();
        public ICollection<ObraPagamento> Pagamentos { get; set; } = new List<ObraPagamento>();
        public ICollection<MovimentoStock> MovimentosStock { get; set; } = new List<MovimentoStock>();
    }
}
