using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Data.Entities;

public class UserImageEntity
{
    [Key, ForeignKey("User")]
    [Column(TypeName = "varchar(36)")]
    public string UserId { get; set; } = null!;
    
    [ProtectedPersonalData]
    [Column(TypeName = "nvarchar(200)")]
    public string? UserImagePath { get; set; }
    
    public virtual UserEntity User { get; set; } = null!;
}