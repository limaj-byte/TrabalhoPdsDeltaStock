namespace DeltaStock.Models
{
    public class Usuario
    {
        public int Id { get; internal set; }
        public string Nome { get; internal set; }
        public string Email { get; internal set; }
        public string Senha { get; internal set; }
        public string Telefone { get; internal set; }
        public string Endereco { get; internal set; }
        public string Tipo { get; internal set; }
        public string Status { get; internal set; }

        //id_usu int primary key auto_increment,
        // nome_usu varchar(300),
        //email_usu varchar(300),
        //senha_usu varchar(300),
        //telefone_usu varchar(100),
        // endereco_usu varchar(300),
        //tipo_usu varchar(100),
        //status_usu varchar(100)
    }
}
