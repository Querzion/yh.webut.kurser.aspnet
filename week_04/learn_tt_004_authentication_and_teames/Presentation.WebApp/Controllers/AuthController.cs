using Business.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.WebApp.Controllers;

public class AuthController(IAuthService authService) : Controller
{
    private readonly IAuthService _authService = authService;
    
    public IActionResult Login(string returnUrl = "~/")
    {
        if (string.IsNullOrWhiteSpace(returnUrl))
            returnUrl = "~/";

        ViewBag.ReturnUrl = returnUrl;
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Login(MemberLoginForm form, string returnUrl = "~/")
    {
        ViewBag.ErrorMessage = "";
    
        if (ModelState.IsValid)
        {
            var result = await _authService.LoginAsync(form);
            if (result)
                return LocalRedirect(string.IsNullOrEmpty(returnUrl) ? "~/" : returnUrl);
        }
        
        ViewBag.ErrorMessage = "Incorrect email or password.";
        return View(form);
        
    }
    
    public IActionResult SignUp()
    {
        ViewBag.ErrorMessage = "";
        
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> SignUp(MemberSignUpForm form)
    {
        if (ModelState.IsValid)
        {
            var result = await _authService.SignUpAsync(form);
            if (result)
                return LocalRedirect("~/");
        }
    
        ViewBag.ErrorMessage = "";
        return View(form);
    }

    public async Task<IActionResult> Logout()
    {
        await _authService.LogoutAsync();
        
        return LocalRedirect("~/");
    }
    
    // [HttpPost]
    // public async Task<IActionResult> Login(MemberLoginForm form, string returnUrl = "~/")
    // {
    //     // ViewBag.ErrorMessage = null;
    //     
    //     if (!ModelState.IsValid)
    //     {
    //         ViewBag.ErrorMessage = "Incorrect email or password.";
    //         return View(form);
    //     }
    //
    //     var result = await _authService.LoginAsync(form);
    //     if (result)
    //     {
    //         return Redirect(returnUrl);
    //     }
    //     else
    //     {
    //         ViewBag.ErrorMessage = "Incorrect email or password.";
    //     }
    //     
    //     return View(form);
    // }
    
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
}