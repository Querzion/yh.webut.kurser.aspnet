using Microsoft.AspNetCore.Mvc;

namespace Presentation.WebApp.Controllers;

public class AuthController : Controller
{
    public IActionResult SignUp()
    {
        ViewData["Title"] = "Sign Up";

        return View();
    }
}