using System.ComponentModel.DataAnnotations;
namespace DeltaStock.Models
{
    public class Categoria
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(300, ErrorMessage = "O nome deve ter no máximo 300 caracteres.")]
        public string Nome { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "A descrição deve ter no máximo 500 caracteres.")]
        public string Descricao { get; set; } = string.Empty;

        [Required(ErrorMessage = "O código é obrigatório.")]
        [StringLength(100, ErrorMessage = "O código deve ter no máximo 100 caracteres.")]
        public string Codigo { get; set; } = string.Empty;

        [Required(ErrorMessage = "A data é obrigatória.")]
        public DateTime? DataCadastroCategoria { get; set; } = DateTime.Today;
        
        [Required(ErrorMessage = "O status é obrigatório.")]
        [StringLength(100, ErrorMessage = "O status deve ter no máximo 100 caracteres.")]
        public string Status { get; set; } = "Ativo";

    }
}
