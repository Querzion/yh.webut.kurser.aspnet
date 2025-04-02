namespace Domain.Models;

public class UserImage
{
    public string UserId { get; set; } = null!;
    
    public string? UserImagePath { get; set; }
    
    public User User { get; set; } = null!;
}