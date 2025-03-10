using Microsoft.AspNetCore.Mvc;
using Presentation.WebApp.Services;

namespace Presentation.WebApp.Controllers;

public class ProductController(ProductService productService) : Controller
{
    private readonly ProductService _productService = productService;

    [Route("product")]
    public IActionResult ProductList()
    {
        ViewData["Title"] = "Products";
        
        var products = _productService.GetProducts();
        
        return View(products);
    }
}