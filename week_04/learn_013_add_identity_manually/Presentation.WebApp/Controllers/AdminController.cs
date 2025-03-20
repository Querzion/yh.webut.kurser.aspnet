using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.WebApp.Controllers;

[Authorize]
public class AdminController : Controller
{
    // [Authorize(Roles = "Administrator")]
    public IActionResult Index()
    {
        return View();
    }
    
    // [AllowAnonymous]
    public IActionResult Clients()
    {
        return View();
    }

    
    // public IActionResult Projects()
    // {
    //     return View();
    // }
}