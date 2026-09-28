using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace DeltaStock.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        [Required(ErrorMessage ="O nome é obrigatorio")]

        [StringLength(300, ErrorMessage = "A descrição deve ter no maximo 300 caracteres.")]
        public string Descricao { get; set; } = string.Empty;
        [Required(ErrorMessage = "O codigo é obrigatorio")]
        public string Codigo{ get; set; } = string.Empty;

        [Required(ErrorMessage = "A data é obrigatória.")]
        public DateTime DataCadastroCategoria { get; set; }
        
        [Required(ErrorMessage = "O status é obrigatorio")]
        public string Status { get; set; } = "Novo";

    }
}
