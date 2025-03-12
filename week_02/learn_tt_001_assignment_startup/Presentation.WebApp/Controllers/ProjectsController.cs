using Microsoft.AspNetCore.Mvc;

namespace Presentation.WebApp.Controllers;

[Route("projects")]
public class ProjectsController : Controller
{
    [Route("")]
    public IActionResult Projects()
    {
        return View();
    }
    
    
    // Https://domain.com/projects/add
    /*[Route("add")]
    public IActionResult AddProject()
    {
        return View();
    }*/
}