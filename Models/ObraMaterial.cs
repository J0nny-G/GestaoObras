namespace GestaoObras.Models
{
    public class ObraMaterial
    {
        public int Id { get; set; }

        // FKs
        public int ObraId { get; set; }
        public Obra? Obra { get; set; }

        public int MaterialId { get; set; }
        public Material? Material { get; set; }

        public int Quantidade { get; set; }
        public DateTime DataHora { get; set; } = DateTime.UtcNow;
    }
}
