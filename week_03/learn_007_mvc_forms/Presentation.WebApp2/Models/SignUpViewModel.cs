using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Presentation.WebApp2.Models;

public class SignUpViewModel
{
    private readonly ClientService _clientService;

    public SignUpViewModel(ClientService clientService)
    {
        _clientService = clientService;
    }
    
    public SignUpFormModel FormData { get; set; } = new();
    public List<SelectListItem> ClientOptions { get; set; } = new();

    public async Task PopulateClientOptions()
    {
        var clients = await _clientService.GetClientsAsync();
        ClientOptions = clients.Select(x => new SelectListItem
        {
            Value = x.Id.ToString(),
            Text = x.ClientName
        }).ToList();

        ClientOptions =
        [
            .. clients.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.ClientName
            })
        ];
    }

}