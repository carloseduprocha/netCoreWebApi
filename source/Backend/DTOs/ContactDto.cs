using System.ComponentModel.DataAnnotations;

namespace Contatos.DTOs
{
    public class ContactDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome é obrigatório")]
        [StringLength(120, MinimumLength = 3,
             ErrorMessage = "Nome deve ter entre 3 e 100 caracteres")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Email é obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        [StringLength(80, ErrorMessage = "Deve ter no máximo 80 caracteres")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Telefone é obrigatório")]
        [Phone(ErrorMessage = "Telefone inválido")]
        [StringLength(15, ErrorMessage = "Deve ter no máximo 15 caracteres [(xx) xxxxx-xxxx]")]
        public string? Phone { get; set; }
    }
}
