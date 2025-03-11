using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entities;

public class ProjectEntity
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [Column(TypeName = "nvarchar(150)")]
    public string Title { get; set; } = null!;
    
    [Column(TypeName = "nvarchar(150)")]
    public string? Description { get; set; }
    
    [Required]
    [Column(TypeName = "date")]
    public DateTime StartDate { get; set; }
    
    [Column(TypeName = "date")]
    public DateTime? EndDate { get; set; }
    
    public int ClientId { get; set; }
    public virtual ClientEntity Client { get; set; } = null!;
    
    public int StatusId { get; set; }
    public virtual StatusEntity Status { get; set; } = null!;
}