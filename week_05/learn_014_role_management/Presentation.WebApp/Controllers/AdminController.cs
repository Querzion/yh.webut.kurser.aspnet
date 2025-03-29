using Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Presentation.WebApp.ViewModels;

namespace Presentation.WebApp.Controllers;

[Authorize(Roles = "Administratör")]
public class AdminController(RoleManager<IdentityRole> roleManager) : Controller
{
    private readonly RoleManager<IdentityRole> _roleManager = roleManager;
    
    public async Task<IActionResult> Index()
    {
        ViewBag.Roles = await _roleManager.Roles.Select(identity => new SelectListItem { Value = identity.Name, Text = identity.Name }).ToListAsync();
        return View();
    }
    
    [AllowAnonymous]
    [Route("denied")]
    public IActionResult Denied()
    {
        
        return View();
    }
}