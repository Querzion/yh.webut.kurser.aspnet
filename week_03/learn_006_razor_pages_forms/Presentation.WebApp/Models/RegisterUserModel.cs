using System.ComponentModel.DataAnnotations;

namespace Presentation.WebApp.Models;

public class RegisterUserModel
{
    [Display(Name = "First name")]
    [Required(ErrorMessage = "You must enter a first name.")]
    public string FirstName { get; set; } = null!;
    
    [Required(ErrorMessage = "You must enter a last name.")]
    public string LastName { get; set; } = null!;
    
    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "You must enter a email.")]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", 
        ErrorMessage = "You must enter a valid email address.")]
    public string Email { get; set; } = null!;
    
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "You must enter a valid password.")]
    [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[\W_])[A-Za-z\d\W_]{8,}$", 
        ErrorMessage = "Password must be at least 8 characters long, include at least one uppercase letter, one lowercase letter, one number, and one special character.")]
    public string Password { get; set; } = null!;
    
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "You must confirm your password.")]
    [Compare(nameof(Password), ErrorMessage = "Passwords do not match.")]
    public string ConfirmPassword { get; set; } = null!;
    
    [Required(ErrorMessage = "You must select a client.")]
    public int ClientId { get; set; }
}