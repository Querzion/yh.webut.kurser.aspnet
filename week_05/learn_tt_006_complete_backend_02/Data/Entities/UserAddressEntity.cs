using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Data.Entities;

public class UserAddressEntity
{
    [Key, ForeignKey("User")]
    [Column(TypeName = "varchar(36)")]
    public string UserId { get; set; } = null!;
    
    [ProtectedPersonalData]
    [Column(TypeName = "nvarchar(150)")]
    public string? StreetName { get; set; }
    
    [ProtectedPersonalData]
    [Column(TypeName = "nvarchar(8)")]
    public string? PostalCode { get; set; }
    
    [ProtectedPersonalData]
    [Column(TypeName = "nvarchar(150)")]
    public string? City { get; set; }
    
    public virtual UserEntity User { get; set; } = null!;
}