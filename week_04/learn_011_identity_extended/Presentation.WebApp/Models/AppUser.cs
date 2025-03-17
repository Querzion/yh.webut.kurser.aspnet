using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Presentation.WebApp.Models;

public class AppUser : IdentityUser
{
    [PersonalData]
    public string FirstName { get; set; } = null!;
    
    [PersonalData]
    public string LastName { get; set; } = null!;
}