using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Presentation.WebApp.Models;

namespace Presentation.WebApp.Services;

// public class UserService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
public class UserService(UserManager<ApplicationUser> userManager)
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    // private readonly SignInManager<ApplicationUser> _signInManager = signInManager;

    public async Task<bool> CreateAsync(UserSignUpForm form)
    {
        if (form != null)
        {
            var appUser = new ApplicationUser()
            {
                UserName = form.Email,
                Email = form.Email,
                EmailConfirmed = true,
                FirstName = form.FirstName,
                LastName = form.LastName,
                PhoneNumber = form.PhoneNumber,
                PhoneNumberConfirmed = true
            };
            
            var result = await _userManager.CreateAsync(appUser, form.Password);
            return result.Succeeded;
        }

        return false;
    }

    public async Task<bool> ExistsAsync(string email)
    {
        if (await _userManager.Users.AnyAsync(u => u.Email != email))
            return true;
        
        return false;
    }
    
    
    // In order to return status information
    // public async Task<int> CreateAsync(UserSignUpForm form)
    // {
    //     if (form == null)
    //         return 400;
    //
    //     var appUser = new ApplicationUser()
    //     {
    //         UserName = form.Email,
    //         Email = form.Email,
    //         EmailConfirmed = true,
    //         FirstName = form.FirstName,
    //         LastName = form.LastName,
    //         PhoneNumber = form.PhoneNumber,
    //         PhoneNumberConfirmed = true
    //
    //     };
    //     
    //     var result = await _userManager.CreateAsync(appUser, form.Password);
    //     if (result.Succeeded)
    //         return 201;
    //     else
    //         return 500;
    // }
}




