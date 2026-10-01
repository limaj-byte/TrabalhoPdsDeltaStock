using System.ComponentModel.DataAnnotations;

namespace DeltaStock.Models
{
    public class Venda
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "A data é obrigatória.")]
        public DateTime? Dataven { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "O valor total é obrigatório.")]
        public float Valortotalven { get; set; }

        [Required(ErrorMessage = "O status é obrigatório.")]
        [StringLength(100, ErrorMessage = "O status deve ter no máximo 100 caracteres.")]
        public string Statusven { get; set; } = string.Empty;

        [Required(ErrorMessage = "O usuário é obrigatório.")]
        public int Idusufk { get; set; }
    }
}