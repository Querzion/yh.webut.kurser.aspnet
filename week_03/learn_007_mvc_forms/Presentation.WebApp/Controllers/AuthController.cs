using Microsoft.AspNetCore.Mvc;

namespace Presentation.WebApp.Controllers;

public class AuthController : Controller
{
    [HttpPost]
    public IActionResult HandleSignUp()
    {
        return RedirectToAction("SignUp", "Account");
    }
}