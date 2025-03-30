using System.ComponentModel.DataAnnotations;
using Domain.Models;

namespace Presentation.WebApp.ViewModels;

public class LoginViewModel
{
    [Required(ErrorMessage = "Required")]
    [Display(Name = "Email Address", Prompt = "Enter your email address.")]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", 
        ErrorMessage = "Invalid Email")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;
    
    
    [Required(ErrorMessage = "Required")]
    [Display(Name = "Password", Prompt = "Enter a password.")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;
    
    public static implicit operator UserLoginModel(LoginViewModel model)
    {
        return model == null
            ? null!
            : new UserLoginModel
            {
                Email = model.Email,
                Password = model.Password
            };
    }
}