using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Presentation.WebApp.Models;

public class ApplicationUser : IdentityUser
{
    [ProtectedPersonalData]
    [Column(TypeName = "nvarchar(100)")]
    public string FirstName { get; set; } = null!;

    [ProtectedPersonalData]
    [Column(TypeName = "nvarchar(100)")]
    public string LastName { get; set; } = null!;
}


// Creata a separate class if you want to add in more data about the user,
// such as geodata(address etc.), name and more, since the class that is based on IdentityUser
// holds Password, Email and UserName.
// public class UserProfile
// {
//     [Key]
//     [PersonalData]
//     public string UserId { get; set; } = null!;
//     
//     [ProtectedPersonalData]
//     public string FirstName { get; set; } = null!;
//     
//     [ProtectedPersonalData]
//     public string LastName { get; set; } = null!;
// }
