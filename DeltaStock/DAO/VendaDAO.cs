namespace DeltaStock.DAO
{
    public class VendaDAO
    {
        public int id { get; set; }
        public DateOnly dataven { get; set; }
        public float valortotalven { get; set; } 
        public string statusven { get; set; } = string.Empty;
        public int idusufk { get; set; }


        //id_ven int primary key auto_increment,
        //data_ven date,
        //valor_total_ven float,
        //status_ven varchar(100),
        //id_usu_fk int
    }
}