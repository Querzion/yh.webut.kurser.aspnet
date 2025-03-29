using Microsoft.AspNetCore.Mvc;

namespace Presentation.WebApp.Controllers;

public class AuthController : Controller
{
    public IActionResult Index()
    {
        ViewData["Title"] = "Home";

        return View();
    }
}