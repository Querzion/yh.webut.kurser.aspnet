using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class TagEntity
{
    [Key]
    public int Id { get; set; }
    
    [Column(TypeName = "nvarchar(75)")]
    public string TagName { get; set; } = null!;
}