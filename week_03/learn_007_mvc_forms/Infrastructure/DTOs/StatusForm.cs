using System.ComponentModel.DataAnnotations;

namespace Infrastructure.DTOs;

public class StatusForm
{
    [Required (ErrorMessage = "Status name is required")]
    [MinLength(2, ErrorMessage = "Status name must be at least 2 characters")]
    public string StatusName { get; set; } = null!;
}