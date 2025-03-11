namespace Infrastructure.Models;

public class Project
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int ClientId { get; set; }
    public int StatusId { get; set; }
    
    public string ClientName { get; set; } = null!;
    public string StatusName { get; set; } = null!;

}