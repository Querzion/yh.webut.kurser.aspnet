using Microsoft.AspNetCore.Mvc;

namespace Presentation.WebApp3.Controllers;

public class ProductsController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}