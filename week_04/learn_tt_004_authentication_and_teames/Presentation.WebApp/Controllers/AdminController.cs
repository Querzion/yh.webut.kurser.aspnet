using Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.WebApp.Controllers;

[Authorize]
public class AdminController(IMemberService memberService) : Controller
{
    private readonly IMemberService _memberService = memberService;

    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult Projects()
    {
        return View();
    }
    
    // [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Members()
    {
        // This can only be done if it's one single list, if it's more advanced layouts,
        // then you insert the model through the code-behind file, since you can only
        // send in one variable through the View this way.
        var members = await _memberService.GetAllMembersAsync();
        
        return View(members);
    }
    
    // [Authorize(Roles = "Admin")]
    public IActionResult Clients()
    {
        return View();
    }
}