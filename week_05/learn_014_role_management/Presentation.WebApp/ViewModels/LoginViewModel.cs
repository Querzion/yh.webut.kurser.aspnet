using System.ComponentModel.DataAnnotations;

namespace Presentation.WebApp.ViewModels;

public class LoginViewModel
{
    [Required(ErrorMessage = "This field is required.")]
    [DataType(DataType.EmailAddress)]
    [Display(Name = "Email Address", Prompt = "Enter email address")]
    public string Email { get; set; } = null!;
    
    
    [Required(ErrorMessage = "This field is required.")]
    [DataType(DataType.Password)]
    [Display(Name = "Password", Prompt = "Enter password")]
    public string Password { get; set; } = null!;
}
