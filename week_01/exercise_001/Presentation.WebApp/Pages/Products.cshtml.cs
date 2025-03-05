using Microsoft.AspNetCore.Mvc.RazorPages;
using Presentation.WebApp.Models;
using Presentation.WebApp.Services;

namespace Presentation.WebApp.Pages;

public class Products : PageModel
{
    private readonly ProductService _productService;

    public Products(ProductService productService)
    {
        _productService = productService;
    }

    // Help from ChatGPT since I felt totally lost with basic stuff like this. :(
    public List<Product> ProductList { get; private set; } = new();

    public void OnGet()
    {
        ProductList = _productService.GetProducts().ToList();
    }
}