using Business.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.WebApp.Controllers;

public class AuthController(IAuthService authService) : Controller
{
    private readonly IAuthService _authService = authService;

    public IActionResult Login()
    {
        ViewBag.ErrorMessage = "";
        
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
                return Redirect(returnUrl);
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
}