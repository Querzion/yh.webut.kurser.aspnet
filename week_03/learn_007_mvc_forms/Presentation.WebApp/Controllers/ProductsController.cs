using Microsoft.AspNetCore.Mvc;

namespace Presentation.WebApp.Controllers;

public class ProductsController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult Details()
    {
        return View();
    }
    
    public IActionResult Edit()
    {
        return View();
    }
    
    public IActionResult Create()
    {
        return View();
    }
}