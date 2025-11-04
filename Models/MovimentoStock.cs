namespace GestaoObras.Models
{
    public class MovimentoStock
    {
        public int Id { get; set; }

        public int? ObraId { get; set; }
        public Obra? Obra { get; set; }

        public int MaterialId { get; set; }
        public Material? Material { get; set; }

        public string Operacao { get; set; } = string.Empty; // ADD ou REMOVE
        public int Quantidade { get; set; }
        public DateTime DataOperacao { get; set; } = DateTime.UtcNow;
    }
}
