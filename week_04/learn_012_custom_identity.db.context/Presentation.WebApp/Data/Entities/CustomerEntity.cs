namespace Presentation.WebApp.Data.Entities;

public class CustomerEntity
{
    public int Id { get; set; }
    public string CustomerName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? PhoneNumber { get; set; }
}