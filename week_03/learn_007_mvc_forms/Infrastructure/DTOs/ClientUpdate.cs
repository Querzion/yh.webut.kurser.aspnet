using System.ComponentModel.DataAnnotations;

namespace Infrastructure.DTOs;

public class ClientUpdate
{
    [Required]
    public int Id { get; set; }
    
    [Required (ErrorMessage = "Client name is required")]
    [MinLength(2, ErrorMessage = "Client name must be at least 2 characters")]
    public string ClientName { get; set; } = null!;
}