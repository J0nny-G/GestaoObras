namespace GestaoObras.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string NIF { get; set; } = string.Empty;
        public string Morada { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? Telefone { get; set; }

        // Relação 1:N → um cliente tem várias obras
        public ICollection<Obra>? Obras { get; set; }
    }
}
