using System.ComponentModel.DataAnnotations;

namespace Presentation.WebApp_MVC.Models;

public class FileUploadViewModel
{
    [Display(Name = "File upload")]
    [Required(ErrorMessage = "You must provide a file for uploading.")]
    public IFormFile File { get; set; } = null!;
}

// public class UserRegistrationFormModel
// {
//     public string FirstName { get; set; } = null!;
//     public string LastName { get; set; } = null!;
//     public string Email { get; set; } = null!;
//     public string Password { get; set; } = null!;
//     public string ConfirmPassword { get; set; } = null!;
//     public IFormFile ProfileAvatar_ImageFile { get; set; } = null!;
//     public IFormFile ProfilePicture_ImageFile { get; set; } = null!;
// }