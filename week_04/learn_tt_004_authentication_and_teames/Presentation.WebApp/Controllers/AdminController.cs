using Microsoft.AspNetCore.Mvc;

namespace Presentation.WebApp.Controllers;

public class AdminController : Controller
{
    public IActionResult Index()
    {
        ViewData["Title"] = "Home";

        return View();
    }
    
    public IActionResult Projects()
    {
        ViewData["Title"] = "Home";

        return View();
    }
    
    public IActionResult Members()
    {
        ViewData["Title"] = "Home";

        return View();
    }
    
    public IActionResult Clients()
    {
        ViewData["Title"] = "Home";

        return View();
    }
}