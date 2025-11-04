namespace GestaoObras.Models
{
    public class Material
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string? Descricao { get; set; }
        public int StockDisponivel { get; set; }

        // Relação N:N com Obra (via ObraMaterial)
        public ICollection<ObraMaterial>? Obras { get; set; }
        public ICollection<MovimentoStock>? Movimentos { get; set; }
    }
}
