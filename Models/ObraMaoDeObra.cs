namespace GestaoObras.Models
{
    public class ObraMaoDeObra
    {
        public int Id { get; set; }

        // FK
        public int ObraId { get; set; }
        public Obra? Obra { get; set; }

        public string Pessoa { get; set; } = string.Empty;
        public double HorasTrabalhadas { get; set; }
        public DateTime DataHora { get; set; } = DateTime.UtcNow;
    }
}
