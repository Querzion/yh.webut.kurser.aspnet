using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Data.Entities;

public class AppUser : IdentityUser
{
    [ProtectedPersonalData]
    [Column(TypeName = "nvarchar(75)")]
    public string? FirstName { get; set; }

    
    [ProtectedPersonalData] 
    [Column(TypeName = "nvarchar(75)")]
    public string? LastName { get; set; }
    
    
    [ProtectedPersonalData]
    [Column(TypeName = "nvarchar(50)")]
    public string? JobTitle { get; set; }
}