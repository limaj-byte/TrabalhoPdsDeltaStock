using System.ComponentModel.DataAnnotations;

namespace DeltaStock.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(300, ErrorMessage = "O nome deve ter no máximo 300 caracteres.")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "Digite um e-mail válido.")]
        [StringLength(300, ErrorMessage = "O e-mail deve ter no máximo 300 caracteres.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "A senha é obrigatória.")]
        [StringLength(300, ErrorMessage = "A senha deve ter no máximo 300 caracteres.")]
        public string Senha { get; set; } = string.Empty;

        [Required(ErrorMessage = "O telefone é obrigatório.")]
        [StringLength(100, ErrorMessage = "O telefone deve ter no máximo 100 caracteres.")]
        public string Telefone { get; set; } = string.Empty;

        [Required(ErrorMessage = "O endereço é obrigatório.")]
        [StringLength(300, ErrorMessage = "O endereço deve ter no máximo 300 caracteres.")]
        public string Endereco { get; set; } = string.Empty;

        [Required(ErrorMessage = "O tipo é obrigatório.")]
        [StringLength(100, ErrorMessage = "O tipo deve ter no máximo 100 caracteres.")]
        public string Tipo { get; set; } = "Vendedor";

        [Required(ErrorMessage = "O status é obrigatório.")]
        [StringLength(100, ErrorMessage = "O status deve ter no máximo 100 caracteres.")]
        public string Status { get; set; } = "Ativo";
    }
}