using Microsoft.AspNetCore.Mvc;
using Presentation.WebApp.Models;

namespace Presentation.WebApp.Controllers;

public class ClientsController : Controller
{
    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Create(ClientCreateFormModel model)
    {
        if (!ModelState.IsValid)
            return View(model);
        
        return View();
    }
}