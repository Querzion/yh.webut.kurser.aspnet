using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.WebApp_Injected.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        ViewData["Title"] = "Home Page";
        
        return View();
    }
}