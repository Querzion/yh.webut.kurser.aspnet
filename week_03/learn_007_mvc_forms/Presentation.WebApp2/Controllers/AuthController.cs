using Microsoft.AspNetCore.Mvc;

namespace Presentation.WebApp2.Controllers;

public class AuthController : Controller
{
    public IActionResult SignUp()
    {
        ViewData["Title"] = "Sign Up";

        return View();
    }
}