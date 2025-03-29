using Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Presentation.WebApp.ViewModels;

namespace Presentation.WebApp.Controllers;

[Authorize]
public class UsersController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager) : Controller
{
    private readonly RoleManager<IdentityRole> _roleManager = roleManager;
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly SignInManager<ApplicationUser> _signInManager = signInManager;

   
    
    public async Task<IActionResult> Index()
    {
        ViewBag.Roles = await _roleManager.Roles.Select(identity => new SelectListItem { Value = identity.Name, Text = identity.Name }).ToListAsync();
        return View();
    }
    
    [Authorize(Roles = "Administratör")]
    [HttpPost]
    public async Task<IActionResult> Index(UserRegistrationViewModel model)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Roles = await _roleManager.Roles.Select(identity => new SelectListItem { Value = identity.Name, Text = identity.Name }).ToListAsync();
            return View(model);
        }

        var user = new ApplicationUser
        {
            UserName = model.Email,
            FirstName = model.FirstName,
            LastName = model.LastName,
            Email = model.Email
        };

        var identityResult = await _userManager.CreateAsync(user, "BytMig123!");
        if (!identityResult.Succeeded)
        {
            ViewBag.ErrorMessage = "Unable to create User";
            ViewBag.Roles = await _roleManager.Roles.Select(identity => new SelectListItem { Value = identity.Name, Text = identity.Name }).ToListAsync();
            return View(model);
        }
        
        var roleResult = await _userManager.AddToRoleAsync(user, model.Role);
        if (!roleResult.Succeeded)
        {
            ViewBag.ErrorMessage = "Unable to assign role to User";
            ViewBag.Roles = await _roleManager.Roles.Select(identity => new SelectListItem { Value = identity.Name, Text = identity.Name }).ToListAsync();
            return View(model);
        }
        
        return RedirectToAction("Index");
    }
    
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Users");
    }
}