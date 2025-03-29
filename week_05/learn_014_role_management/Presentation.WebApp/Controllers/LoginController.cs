using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Presentation.WebApp.ViewModels;

namespace Presentation.WebApp.Controllers;

public class LoginController(SignInManager<ApplicationUser> signInManager) : Controller
{
    private readonly SignInManager<ApplicationUser> _signInManager = signInManager;

    public IActionResult Index()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Index(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
            if (result.Succeeded)
            {
                Console.WriteLine("Login successful. Redirecting to Users.");
                return RedirectToAction("Index", "Users");
            }
            else
            {
                Console.WriteLine("Login failed.");
                ViewBag.ErrorMessage = "Incorrect Email or Password.";
            }
        }

        ViewBag.ErrorMessage = "Incorrect Email or Password.";
        return View(model);
    }
}