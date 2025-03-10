using System.Diagnostics;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.WebApp_UnInjected.Controllers;

public class HomeController(ProductService productService) : Controller
{
    private readonly ProductService _productService = productService;

    public IActionResult Index()
    {
        return View(_productService.GetProducts());
    }
}