namespace DeltaStock.DAO
{
    public class VendaDAO
    {
        public int id { get; set; }
        public DateOnly data_ven { get; set; }
        public float valor_total_ven { get; set; } 
        public string status_ven { get; set; } = string.Empty;
        public int id_usu_fk { get; set; }


        //id_ven int primary key auto_increment,
        //data_ven date,
        //valor_total_ven float,
        //
    }
}






//id_cat int primary key auto_increment,
//nome_cat varchar(300),
//descricao_cat varchar(500),
//codigo_cat varchar(100),
//status_cat varchar(100),
//data_cadastro_cat date