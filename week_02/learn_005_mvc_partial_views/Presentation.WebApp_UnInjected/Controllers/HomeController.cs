using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.WebApp_UnInjected.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}