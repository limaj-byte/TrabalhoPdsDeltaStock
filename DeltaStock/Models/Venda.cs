namespace DeltaStock.Models
{
    public class Venda
    {
        public int Id { get; set; }
        public DateTime Dataven { get; set; }
        public float Valortotalven { get; set; }
        public string Statusven { get; set; } = string.Empty;   
        public int Idusufk { get; set; }


    }
}
