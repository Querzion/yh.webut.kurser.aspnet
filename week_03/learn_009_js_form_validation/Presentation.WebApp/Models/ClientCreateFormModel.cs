using System.ComponentModel.DataAnnotations;

namespace Presentation.WebApp.Models;

public class ClientCreateFormModel
{
    [Display(Name = "Client Name", Prompt = "Enter Client Name")]
    [Required(ErrorMessage = "Required")]
    public string ClientName { get; set; } = null!;
    
    
    [Display(Name = "Contact Person", Prompt = "Enter a Contact Person")]
    [Required(ErrorMessage = "Required")]
    public string ContactPerson { get; set; } = null!;
    
    
    [DataType(DataType.EmailAddress)]
    [Display(Name = "Email", Prompt = "Enter an Email Address")]
    [Required(ErrorMessage = "Required")]
    [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Invalid email")]
    public string Email { get; set; } = null!;
    
    
    [DataType(DataType.PhoneNumber)]
    [Display(Name = "Phone Number", Prompt = "Enter a Phone Number")]
    public string? PhoneNumber { get; set; }
}