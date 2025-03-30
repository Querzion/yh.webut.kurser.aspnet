using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.WebApp.Controllers;

[Authorize(Policy = "Admins")]
public class MembersController : Controller
{
    [Route("admin/members")]
    public IActionResult Index()
    {
        ViewData["Title"] = "Home";

        return View();
    }
    
    [AllowAnonymous]
    [Route("denied")]
    public IActionResult Denied()
    {
        return View();
    }
}