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

        //id_cat int primary key auto_increment,
        //nome_cat varchar(300),
        //descricao_cat varchar(500),
        //codigo_cat varchar(100),
        //status_cat varchar(100),
        //data_cadastro_cat date

        //public int Id { get; set; }
        //public string Numero { get; set; } = string.Empty;
        //public DateOnly Data { get; set; }
        //public string Interessado { get; set; } = string.Empty;
        //public string Assunto { get; set; } = string.Empty;
        //public string Descricao { get; set; } = string.Empty;
        //public string Situacao { get; set; } = string.Empty;
    }
}
