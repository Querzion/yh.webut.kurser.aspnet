using Microsoft.AspNetCore.Identity;

namespace Data.Entities;

public class Member : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}