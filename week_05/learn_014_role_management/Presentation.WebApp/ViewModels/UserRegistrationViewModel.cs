using System.ComponentModel.DataAnnotations;
using Data.Entities;

namespace Presentation.WebApp.ViewModels;

public class UserRegistrationViewModel
{
    [Required(ErrorMessage = "This field is required.")]
    [DataType(DataType.Text)]
    [Display(Name = "First Name", Prompt = "Enter first name")]
    public string FirstName { get; set; } = null!;
    
    
    [Required(ErrorMessage = "This field is required.")]
    [DataType(DataType.Text)]
    [Display(Name = "Last Name", Prompt = "Enter last name")]
    public string LastName { get; set; } = null!;
    
    
    [Required(ErrorMessage = "This field is required.")]
    [DataType(DataType.EmailAddress)]
    [Display(Name = "Email Address", Prompt = "Enter email address")]
    public string Email { get; set; } = null!;
    
    
    [Required(ErrorMessage = "This field is required.")]
    [Display(Name = "Role", Prompt = "Select a role")]
    public string Role { get; set; } = null!;
}