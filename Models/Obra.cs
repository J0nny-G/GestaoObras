namespace GestaoObras.Models
{
    public class Obra
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string? Descricao { get; set; }
        public string? Morada { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public bool Ativa { get; set; } = true;

        // FK Cliente
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }

        // Relações
        public ICollection<ObraMaterial> Materiais { get; set; } = new List<ObraMaterial>();
        public ICollection<ObraMaoDeObra> MaoDeObra { get; set; } = new List<ObraMaoDeObra>();
        public ICollection<ObraPagamento> Pagamentos { get; set; } = new List<ObraPagamento>();
        public ICollection<MovimentoStock> MovimentosStock { get; set; } = new List<MovimentoStock>();
    }
}
