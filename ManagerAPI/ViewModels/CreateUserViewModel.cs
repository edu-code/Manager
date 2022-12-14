using System.ComponentModel.DataAnnotations;

namespace ManagerAPI.ViewModels;

public class CreateUserViewModel
{
    [Required(ErrorMessage = "O nome não pode ser vazio.")]
    [MinLength(3, ErrorMessage = "O nome deve ter no mínimo 3 caracteres.")]
    [MaxLength(80, ErrorMessage = "O nome deve ter no máximo 80 caracteres")]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "O email não pode ser vazio.")]
    [MinLength(10, ErrorMessage = "O email deve ter no mínimo 10 caracteres.")]
    [MaxLength(180, ErrorMessage = "O email deve ter no máximo 180 caracteres")]
    [EmailAddress(ErrorMessage = "Email não válido")]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "A senha não pode ser vazia.")]
    [MinLength(6, ErrorMessage = "A senha deve ter no mínimo 6 caracteres.")]
    [MaxLength(16, ErrorMessage = "A senha deve ter no máximo 16 caracteres")]
    public string Password { get; set; }
}