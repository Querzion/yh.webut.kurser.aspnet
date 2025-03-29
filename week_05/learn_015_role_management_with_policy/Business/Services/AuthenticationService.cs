using Business.Factories;
using Business.Interfaces;
using Data.Entities;
using Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace Business.Services;

public class AuthenticationService(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
    : IAuthenticationService
{
    private readonly SignInManager<ApplicationUser> _signInManager = signInManager;
    private readonly UserManager<ApplicationUser> _userManager = userManager;

    public async Task<bool> LoginAsync(UserLoginModel loginForm)
    {
        var result = await _signInManager.PasswordSignInAsync(loginForm.Email, loginForm.Password, false, false);
        return result.Succeeded;
    }
    
    public async Task<bool> RegisterUserAsync(UserRegistrationModel form)
    {
        var memberEntity = UserFactory.ToEntity(form);
        
        var result = await _userManager.CreateAsync(memberEntity, form.Password);
        return result.Succeeded;
    }
    
    public async Task LogoutAsync()
    {
        await _signInManager.SignOutAsync();
    }
}