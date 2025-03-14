using System.ComponentModel.DataAnnotations;

namespace Presentation.WebApp.Models;

public class SignUpFormModel
{
    [Display(Name = "First name", Prompt = "Enter your first name")]
    [Required(ErrorMessage = "You must enter a first name.")]
    public string FirstName { get; set; } = null!;
    
    [Display(Name = "Last name", Prompt = "Enter your last name")]
    [Required(ErrorMessage = "You must enter a last name.")]
    public string LastName { get; set; } = null!;
    
    [DataType(DataType.EmailAddress)]
    [Display(Name = "Email address", Prompt = "Enter your email address.")]
    [Required(ErrorMessage = "You must enter a email.")]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", 
        ErrorMessage = "You must enter a valid email address.")]
    public string Email { get; set; } = null!;
    
    [DataType(DataType.Password)]
    [Display(Name = "Password", Prompt = "Enter a password")]
    [Required(ErrorMessage = "You must enter a valid password.")]
    [RegularExpression(@"^(?=.*[A-Ö])(?=.*[a-ö])(?=.*\d)(?=.*[\W_])[A-Za-z\d\W_]{8,}$", 
        ErrorMessage = "Password must be at least 8 characters long, include at least one uppercase letter, one lowercase letter, one number, and one special character.")]
    public string Password { get; set; } = null!;
    
    [DataType(DataType.Password)]
    [Display(Name = "Confirm password", Prompt = "Confirm the password")]
    [Required(ErrorMessage = "You must confirm your password.")]
    [Compare(nameof(Password), ErrorMessage = "Passwords do not match.")]
    public string ConfirmPassword { get; set; } = null!;
    
    [Display(Name = "Select a Client", Prompt = "Select a Client")]
    [Required(ErrorMessage = "You must select a client.")]
    public int ClientId { get; set; }
}