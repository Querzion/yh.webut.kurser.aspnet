using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Presentation.WebApp3.Models;

namespace Presentation.WebApp3.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        // ViewData can be placed either here, or in the Index.cshtml file.
        ViewData["Title"] = "Home";
        
        return View();
    }

    public IActionResult About()
    {
        ViewData["Title"] = "About Us";
        return View();
    }

    public IActionResult Contact()
    {
        ViewData["Title"] = "Contact Us";
        return View();
    }
    
}