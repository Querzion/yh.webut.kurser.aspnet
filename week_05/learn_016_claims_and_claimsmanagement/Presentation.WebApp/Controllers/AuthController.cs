using Business.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.WebApp.ViewModels;

namespace Presentation.WebApp.Controllers;

[Route("auth")]
public class AuthController(IAuthenticationService authenticationService) : Controller
{
    private readonly IAuthenticationService _authenticationService = authenticationService;
    
    [Route("signup")]
    public IActionResult SignUp()
    {
        return View();
    }
    
    [HttpPost]
    [Route("signup")]
    public async Task<IActionResult> SignUp(SignUpViewModel model, string returnUrl = "~/")
    {
        if (ModelState.IsValid)
        {
            var user = new UserRegistrationModel
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Password = model.Password
            };
            
            var result = await _authenticationService.RegisterUserAsync(user);
            if (result)
                return LocalRedirect(returnUrl);
        }
        
        return View(model);
    }

    [Route("login")]
    public IActionResult Login()
    {
        return View();
    }

    // [HttpPost]
    // [Route("login")]
    // public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = "~/")
    // {
    //     if (ModelState.IsValid)
    //     {
    //         var result = await _authenticationService.LoginAsync(model);
    //         if (result)
    //             return LocalRedirect(returnUrl);
    //     }
    //
    //     ViewBag.ErrorMessage = "Unable to login. Try another email or password.";
    //     return View();
    // }
    
    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = "~/")
    {
        if (ModelState.IsValid)
        {
            var result = await _authenticationService.LoginAsync(model.Email, model.Password);
            if (result.Succeeded)
                return LocalRedirect(returnUrl);
        }

        ViewBag.ErrorMessage = "Unable to login. Try another email or password.";
        return View(model);
    }

    [Route("logout")]
    [Authorize]
    public async Task<IActionResult> Logout()
    {
        await _authenticationService.LogoutAsync();
        return LocalRedirect("~/auth/login");
    }
}