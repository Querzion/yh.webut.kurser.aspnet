using Microsoft.AspNetCore.Mvc;

namespace Presentation.WebApp4_CleanStart.Controllers;

public class HomeController : Controller
{
    // GET
    public IActionResult Index()
    {
        ViewData["Title"] = "Home";
        return View();
    }
}