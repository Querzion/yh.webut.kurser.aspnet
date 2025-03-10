using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entities;

public class ClientEntity
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [Column(TypeName = "nvarchar(150)")]
    public string ClientName { get; set; } = null!;
    
    public virtual ICollection<ProjectEntity> Projects { get; set; } = [];
}