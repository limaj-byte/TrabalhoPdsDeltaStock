using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.Xml;
using static Mysqlx.Expect.Open.Types.Condition.Types;

namespace DeltaStock.Models;

public class Produto
{
    public int Id { get; set; }
    public string Codigo { get; set; } = string.Empty;
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public string Quantidade { get; set; } = string.Empty;
    public string Custo { get; set; } = string.Empty;
    public string Valor_venda { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public DateOnly Data_cadastro { get; set; }




}
