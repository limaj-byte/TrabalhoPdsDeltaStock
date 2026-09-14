namespace DeltaStock.DAO
{
    public class Movimentacao
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string Tipo { get; set; } = string.Empty;
        public int Quantidade { get; set; }
        public int SaldoAnterior { get; set; }
        public int SaldoFinal { get; set; }
        public string Origem { get; set; } = string.Empty;
        public string? Id_documento { get; set; }
        public string? Motivo { get; set; }

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