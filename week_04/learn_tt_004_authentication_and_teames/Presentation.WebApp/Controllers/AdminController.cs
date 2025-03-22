using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.WebApp.Controllers;

[Authorize]
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
    
    // [Authorize(Roles = "Admin")]
    public IActionResult Members()
    {
        ViewData["Title"] = "Home";

        return View();
    }
    
    // [Authorize(Roles = "Admin")]
    public IActionResult Clients()
    {
        ViewData["Title"] = "Home";

        return View();
    }
}