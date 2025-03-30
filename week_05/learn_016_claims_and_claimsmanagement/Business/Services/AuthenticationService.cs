using System.Security.Claims;
using Business.Factories;
using Business.Interfaces;
using Data.Entities;
using Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace Business.Services;

public class AuthenticationService(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    : IAuthenticationService
{
    private readonly SignInManager<ApplicationUser> _signInManager = signInManager;
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly RoleManager<IdentityRole> _roleManager = roleManager;

    // public async Task<bool> LoginAsync(UserLoginModel loginForm)
    // {
    //     var result = await _signInManager.PasswordSignInAsync(loginForm.Email, loginForm.Password, false, false);
    //     return result.Succeeded;
    // }

    #region Teachers LoginAsync

        #region Works

            // public async Task<SignInResult> LoginAsync(string email, string password, bool rememberMe = false)
            // {
            //     var user = await _userManager.FindByEmailAsync(email);
            //     if (user != null)
            //     {
            //         var result = await _signInManager.PasswordSignInAsync(email, password, rememberMe, lockoutOnFailure: false);
            //         if (result.Succeeded)
            //         {
            //             var claims = await _userManager.GetClaimsAsync(user);
            //
            //             if (!claims.Any(x => x.Type == "DisplayName"))
            //             {
            //                 var displayName = $"{user.FirstName} {user.LastName}";
            //                 await _userManager.AddClaimAsync(user, new Claim("DisplayName", displayName));
            //             }
            //         }
            //         return result;
            //     }
            //     return new SignInResult();
            // }

        #endregion

        #region It now works, I had missed a ! in AddClaimsByEmail();

            public async Task<SignInResult> LoginAsync(string email, string password, bool rememberMe = false)
            { 
                var result = await _signInManager.PasswordSignInAsync(email, password, rememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    var user = await _userManager.FindByEmailAsync(email);
                    if (user != null)
                    {
                        await AddClaimsByEmailAsync(user, "DisplayName", $"{user.FirstName} {user.LastName}");
                    }
                }
                return result;
            }

            private async Task AddClaimsByEmailAsync(ApplicationUser user, string typeName, string value)
            {
                if (user != null)
                {
                    var claims = await _userManager.GetClaimsAsync(user);

                    if (!claims.Any(x => x.Type == typeName))
                    {
                        await _userManager.AddClaimAsync(user, new Claim(typeName, value));
                    }
                }
            }

        #endregion
        
    #endregion
    
    public async Task<bool> RegisterUserAsync(UserRegistrationModel form)
    {
        var memberEntity = UserFactory.ToEntity(form);
        
        var result = await _userManager.CreateAsync(memberEntity, form.Password);
        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(memberEntity, "User");
        }
        
        return result.Succeeded;
    }
    
    public async Task LogoutAsync()
    {
        await _signInManager.SignOutAsync();
    }
}