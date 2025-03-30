using Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace Business.Interfaces;

public interface IAuthenticationService
{
    // Task<bool> LoginAsync(UserLoginModel loginForm);
    Task<SignInResult> LoginAsync(string email, string password, bool rememberMe = false);
    Task<bool> RegisterUserAsync(UserRegistrationModel model);
    Task LogoutAsync();
}