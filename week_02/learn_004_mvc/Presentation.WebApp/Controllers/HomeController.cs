using Microsoft.AspNetCore.Mvc;

namespace Presentation.WebApp.Controllers;

public class HomeController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}