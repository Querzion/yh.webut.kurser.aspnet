using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

// public class MemberLoginFormWRECKED
// {
//     [DataType(DataType.EmailAddress)]
//     [Display(Name = "Email", Prompt = "Enter email address")]
//     public string? Email { get; set; }
//     
//     [DataType(DataType.Password)]
//     [Display(Name = "Password", Prompt = "Enter password")]
//     public string? Password { get; set; }
// }

public class MemberLoginForm
{
    [Required(ErrorMessage = "Email is required.")]
    [DataType(DataType.EmailAddress)]
    [Display(Name = "Email", Prompt = "Enter email address")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "A password is required.")]
    [DataType(DataType.Password)]
    [Display(Name = "Password", Prompt = "Enter password")]
    public string? Password { get; set; }
}