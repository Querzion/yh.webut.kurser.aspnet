using Microsoft.AspNetCore.Mvc;

namespace Presentation.WebApp.Controllers;

public class AccountController : Controller
{
    public IActionResult SignUp()
    {
        return View();
    }
}