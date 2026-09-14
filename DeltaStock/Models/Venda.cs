namespace DeltaStock.Models
{
    public class Venda
    {
        public int Id { get; set; }
        public DateTime Dataven { get; set; }
        public float Valortotalven { get; set; }
        public string Statusven { get; set; } = string.Empty;   
        public int Idusufk { get; set; }


        //id_ven int primary key auto_increment,
        //data_ven date,
        //valor_total_ven float,
        //status_ven varchar(100),
        //id_usu_fk int
    }
}
