using Microsoft.AspNetCore.Mvc;

namespace Presentation.WebApp.Controllers;

public class AuthController : Controller
{
    [Route("register")]
    public IActionResult Register()
    {
        ViewData["Title"] = "Home";

        return View();
    }
    
    public IActionResult Login()
    {
        ViewData["Title"] = "Home";

        return View();
    }
}