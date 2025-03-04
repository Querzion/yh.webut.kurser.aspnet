using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Presentation.WebApp2.Models;

namespace Presentation.WebApp2.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        var viewModel = new HomeIndexViewModel();
        
        return View(viewModel);
    }
    
    // MVC Controllers can be used for smaller pages too, 
    // wherein you route the sections as their own pages like this.
    // [Route("about")]
    // public IActionResult About()
    // {
    //     return View();
    // }
}