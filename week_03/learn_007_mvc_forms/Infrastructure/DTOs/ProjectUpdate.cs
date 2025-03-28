using System.ComponentModel.DataAnnotations;

namespace Infrastructure.DTOs;

public class ProjectUpdate
{
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "Project title is required")]
    [MinLength(2, ErrorMessage = "Title must be at least 2 characters")]
    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    [Required(ErrorMessage = "Start date is required")]
    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    // Include connection fields for related entities
    [Required(ErrorMessage = "Client ID is required")]
    public int ClientId { get; set; }

    [Required(ErrorMessage = "Status ID is required")]
    public int StatusId { get; set; }
}