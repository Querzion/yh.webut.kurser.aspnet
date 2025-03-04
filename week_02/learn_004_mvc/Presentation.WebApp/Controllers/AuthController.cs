using Microsoft.AspNetCore.Mvc;

namespace Presentation.WebApp.Controllers;

public class AuthController : Controller
{
    [Route("signup")]
    public IActionResult SignUp()
    {
        return View();
    }
    
    [Route("signin")]
    public IActionResult SignIn()
    {
        return View();
    }
    
    public new IActionResult SignOut()
    {
        return RedirectToAction("Index", "Home");
    }
}