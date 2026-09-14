using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.Xml;
using static Mysqlx.Expect.Open.Types.Condition.Types;

namespace DeltaStock.Models;

public class Produto
{
    public int id_prod { get; set; }
    public string codigo_prod { get; set; } = string.Empty;
    public string nome_prod { get; set; } = string.Empty;
    public string descricao_prod { get; set; } = string.Empty;
    public string quantidade_prod { get; set; } = string.Empty;
    public string custo_prod { get; set; } = string.Empty;
    public string valor_venda_prod { get; set; } = string.Empty;
    public string status_prod { get; set; } = string.Empty;
    public DateOnly data_cadastro_prod { get; set; }



//    CREATE TABLE Produto(
//    id_prod int primary key auto_increment,
//    codigo_prod varchar(100),
//    nome_prod varchar(300),
//    descricao_prod varchar(500),
//    quantidade_prod int,
//    custo_prod float,
//    valor_venda_prod float,
//    status_prod varchar(100),
//    data_cadastro_prod date,
//    id_cat_fk int,
//    foreign key(id_cat_fk) references Categoria(id_cat),
//    id_forn_fk int,
//    foreign key(id_forn_fk) references Fornecedor(id_forn)
//);


}
