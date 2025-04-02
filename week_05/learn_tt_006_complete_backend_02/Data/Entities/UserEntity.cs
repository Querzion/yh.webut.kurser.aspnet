using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Data.Entities;

public class UserEntity : IdentityUser
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
    
    
    [ProtectedPersonalData]
    public DateTime? DateOfBirth { get; set; }
    
    public virtual UserAddressEntity? Address { get; set; }
    public virtual UserImageEntity? MemberImage { get; set; }
    
    public virtual ICollection<ProjectEntity> Projects { get; set; } = [];
}