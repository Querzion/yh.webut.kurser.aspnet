using Microsoft.AspNetCore.Mvc;

namespace Presentation.WebApp.Controllers;

public class AboutController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}