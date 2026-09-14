namespace DeltaStock.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string Codigo{ get; set; } = string.Empty;
        public string Status{ get; set; } = string.Empty;
        public DateTime DataCadastroCategoria { get; set; }

    }
}
