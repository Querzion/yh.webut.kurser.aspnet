using Domain.Models;

namespace Business.Interfaces;

public interface IAuthenticationService
{
    Task<bool> LoginAsync(UserLoginModel loginForm);
    Task<bool> RegisterUserAsync(UserRegistrationModel model);
    Task LogoutAsync();
}