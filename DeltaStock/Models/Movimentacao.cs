namespace DeltaStock.Models
{
    public class Movimentacao
    {
        public int id_mov { get; set; }
        public DateTime data_mov { get; set; }
        public string tipo_mov { get; set; } = string.Empty;
        public int quantidade_mov { get; set; }
        public int saldo_anterior_mov { get; set; }
        public int saldo_final_mov { get; set; }
        public string origem_mov { get; set; } = string.Empty;
        public string? id_documento_mov { get; set; }
        public string? motivo_mov { get; set; }
        public int id_prod_fk { get; set; }
        public int id_usu_fk { get; set; }

        //id_mov int primary key auto_increment,
        //data_mov datetime,
        //tipo_mov varchar(100),
        //quantidade_mov int,
        //saldo_anterior_mov int,
        //saldo_final_mov int,
        //origem_mov varchar(300),
        //id_documento_mov varchar(300),
        //motivo_mov varchar(500),
        //id_prod_fk int,
        //foreign key(id_prod_fk) references Produto(id_prod),
        //id_usu_fk int,
        //foreign key(id_usu_fk) references Usuario(id_usu)
    }
}