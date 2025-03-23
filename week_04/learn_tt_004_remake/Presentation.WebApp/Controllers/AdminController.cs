using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.WebApp.Controllers;

[Authorize]
public class AdminController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult Projects()
    {
        return View();
    }
    
    // [Authorize(Roles = "Admin")]
    public IActionResult Members()
    {
        return View();
    }
    
    // [Authorize(Roles = "Admin")]
    public IActionResult Clients()
    {
        return View();
    }
}