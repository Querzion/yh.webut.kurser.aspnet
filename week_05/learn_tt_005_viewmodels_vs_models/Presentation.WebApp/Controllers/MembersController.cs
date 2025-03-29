using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Presentation.WebApp.ViewModels;

namespace Presentation.WebApp.Controllers;

public class MemberController(IMemberService memberService) : Controller
{
    private readonly IMemberService _memberService = memberService;

    public async Task<IActionResult> Index()
    {
        var viewModel = new MembersViewModel
        {
            Title = "Members",
            Members = await _memberService.GetMembersAsync()
        };
        
        return View(viewModel);
    }
}