using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Presentation.WebApp.Services;

namespace Presentation.WebApp.Controllers;

// If ProductService is NOT injected through the view imports or injected separately, 
// then you will have to initialize the service from the controller!
public class HomeController(ProductService productService) : Controller
{
    private readonly ProductService _productService = productService;

    public IActionResult Index()
    {
        ViewData["Title"] = "Home";
        
        return View(_productService.GetProducts());
    }
}