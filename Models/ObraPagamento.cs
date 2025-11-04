namespace GestaoObras.Models
{
    public class ObraPagamento
    {
        public int Id { get; set; }

        // FK
        public int ObraId { get; set; }
        public Obra? Obra { get; set; }

        public string Pessoa { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public DateTime DataHora { get; set; } = DateTime.UtcNow;
    }
}
