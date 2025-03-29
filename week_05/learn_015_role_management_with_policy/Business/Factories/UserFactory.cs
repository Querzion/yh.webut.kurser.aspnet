using Data.Entities;
using Domain.Models;

namespace Business.Factories;

public class UserFactory
{
    public static ApplicationUser ToEntity(UserRegistrationModel form)
    {
        return form == null
            ? new ApplicationUser()
            : new ApplicationUser
            {
                UserName = form.Email,
                FirstName = form.FirstName,
                LastName = form.LastName,
                Email = form.Email
            };
    }
    
    // From Entity to Model
    public static Member ToModel(ApplicationUser user)
    {
        return user == null
            ? new Member()
            : new Member
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email!,
                PhoneNumber = user.PhoneNumber
            };
    }
}