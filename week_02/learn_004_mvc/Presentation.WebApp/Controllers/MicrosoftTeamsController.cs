using Microsoft.AspNetCore.Mvc;

namespace Presentation.WebApp.Controllers;

public class MicrosoftTeamsController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult SmallMediumBusiness() => View();
}