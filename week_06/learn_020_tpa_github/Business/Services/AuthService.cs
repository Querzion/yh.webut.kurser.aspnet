using Business.Models;
using Data.Entities;
using Domain.DTOs;
using Domain.DTOs.Authentication;
using Microsoft.AspNetCore.Identity;

namespace Business.Services;

public interface IAuthService
{
    Task<AuthServiceResult> SignInAsync(SignInFormData formData);
    Task<AuthServiceResult> SignUpAsync(SignUpFormData formData);
    Task<AuthServiceResult> SignOutAsync();
}

public class AuthService(IUserService userService, SignInManager<AppUser> signInManager) : IAuthService
{
    private readonly IUserService _userService = userService;
    private readonly SignInManager<AppUser> _signInManager = signInManager;

    public async Task<AuthServiceResult> SignInAsync(SignInFormData formData)
    {
        if (formData == null)
            return new AuthServiceResult
                { Succeeded = false, StatusCode = 400, Error = "Not all required fields are supplied." };
        
        var result = await _signInManager.PasswordSignInAsync(formData.Email, formData.Password, formData.IsPersistent, false);
        return result.Succeeded
            ? new AuthServiceResult { Succeeded = true, StatusCode = 200 }
            : new AuthServiceResult { Succeeded = false, StatusCode = 401, Error = "Invalid email or password." };
    }

    public async Task<AuthServiceResult> SignUpAsync(SignUpFormData formData)
    {
        if (formData == null)
            return new AuthServiceResult
                { Succeeded = false, StatusCode = 400, Error = "Not all required fields are supplied." };

        var result = await _userService.CreateUserAsync(formData);
        return result.Succeeded
            ? new AuthServiceResult { Succeeded = true, StatusCode = 201 }
            : new AuthServiceResult { Succeeded = false, StatusCode = result.StatusCode, Error = result.Error };
    }
    
    public async Task<AuthServiceResult> SignOutAsync()
    {
        await _signInManager.SignOutAsync();
        return new AuthServiceResult { Succeeded = true, StatusCode = 200 };
    }
}