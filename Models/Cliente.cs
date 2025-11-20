using System.ComponentModel.DataAnnotations;

namespace GestaoObras.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome não pode ter mais de 100 caracteres.")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O NIF é obrigatório.")]
        [RegularExpression(@"^\d{9}$", ErrorMessage = "O NIF deve ter exatamente 9 dígitos.")]
        [Display(Name = "NIF")]
        public string NIF { get; set; } = string.Empty;

        [Required(ErrorMessage = "A morada é obrigatória.")]
        [StringLength(200, ErrorMessage = "A morada não pode ter mais de 200 caracteres.")]
        [Display(Name = "Morada")]
        public string Morada { get; set; } = string.Empty;

        [EmailAddress(ErrorMessage = "Introduza um email válido.")]
        [StringLength(100, ErrorMessage = "O email não pode ter mais de 100 caracteres.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "O telefone é obrigatório.")]
        [RegularExpression(@"^[0-9]{9,15}$", ErrorMessage = "O telefone deve conter apenas números (9 a 15 dígitos).")]
        [StringLength(15, ErrorMessage = "O telefone não pode ter mais de 15 dígitos.")]
        [Display(Name = "Telefone")]
        public string Telefone { get; set; } = string.Empty;

        // Relação 1:N → um cliente tem várias obras
        public ICollection<Obra>? Obras { get; set; }
    }
}
