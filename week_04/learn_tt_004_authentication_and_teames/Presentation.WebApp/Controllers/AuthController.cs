using Business.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.WebApp.Controllers;

public class AuthController(IAuthService authService) : Controller
{
    private readonly IAuthService _authService = authService;
    
    public IActionResult Login()
    {
        ViewBag.ErrorMessage = null;
        
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Login(MemberLoginForm form, string returnUrl = "~/")
    {
        ViewBag.ErrorMessage = null;
        
        if (!ModelState.IsValid)
        {
            ViewBag.ErrorMessage = "Incorrect email or password.";
            return View(form);
        }
    
        var result = await _authService.LoginAsync(form);
        if (result)
        {
            return Redirect(returnUrl);
        }
        else
        {
            ViewBag.ErrorMessage = "Incorrect email or password.";
        }
        
        return View();
    }
    
    // [HttpPost]
    // public async Task<IActionResult> Login(MemberLoginFormWRECKED form, string returnUrl = "~/")
    // {
    //     // Empty the ViewBag
    //     // ViewBag.ErrorMessage = string.Empty;
    //     // ViewBag.ErrorMessage = "";
    //     ViewBag.ErrorMessage = null;
    //     
    //     // Validate form so that it's not empty.
    //     if (string.IsNullOrWhiteSpace(form.Email) || string.IsNullOrWhiteSpace(form.Password))
    //     {
    //         ViewBag.Error = "Incorrect email or password.";
    //         return View(form);
    //     }
    //     
    //     // if (!await authService.UserExists(form.Email))
    //     // {
    //     //     ViewBag.Error = "Please Register. Email not found.";
    //     //     return View(form);
    //     // }
    //     
    //     return View();
    // }
    
    // public IActionResult Register()
    // {
    //     return View();
    // }
    
    // [HttpPost]
    // public IActionResult Register(MemberRegistrationForm form)
    // {
    //     return View();
    // }
}