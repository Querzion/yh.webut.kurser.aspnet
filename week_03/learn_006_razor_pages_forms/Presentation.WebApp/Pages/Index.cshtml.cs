using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Presentation.WebApp.Models;

namespace Presentation.WebApp.Pages;

public class IndexModel(ClientService clientService) : PageModel
{
    private readonly ClientService _clientService = clientService;
    
    [BindProperty] 
    public RegisterUserModel FormData { get; set; } = new();
    
    public List<SelectListItem> ClientOptions { get; set; } = [];
    
    public async Task OnGet()
    {
        var clients = await _clientService.GetClientsAsync();
        // Old way to write this
        // ClientOptions = clients.Select(x => new SelectListItem
        // {
        //     Value = x.Id.ToString(),
        //     Text = x.ClientName
        // }).ToList();
        
        // New way to write this.
        ClientOptions = [.. clients.Select(x => new SelectListItem
        {
           Value = x.Id.ToString(),
           Text = x.ClientName
        })];
    }
    
    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
            return Page();
        
        return RedirectToPage("/Index");
    }
}