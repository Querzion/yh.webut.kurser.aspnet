using Infrastructure.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Presentation.WebApp2.Models;

public class SignUpViewModel(ClientService clientService)
{
    private readonly ClientService _clientService = clientService;


    // Get information when ready(basically after a refresh or something.
    // public SignUpViewModel(ClientService clientService)
    // {
    //     _clientService = clientService;
    //     // Task.Run(PopulateClientOptionsAsync);
    //     PopulateClientOptionsAsync().ConfigureAwait(false).GetAwaiter().GetResult();
    // }
    
    public SignUpFormModel FormData { get; set; } = new();
    public List<SelectListItem> ClientOptions { get; set; } = new();

    public async Task PopulateClientOptionsAsync()
    {

        #region ChatGPT generated code

            var result = await _clientService.GetAllClientsAsync();
            
            if (!result.Success) // Check if the result is successful
            {
                // Handle error (logging, showing a message, etc.)
                return;
            }

            var clients = (result as Result<IEnumerable<Client>>)?.Data ?? [];

        #endregion

        ClientOptions =
        [
            ..clients.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.ClientName
            })
        ];
        
        // Old way of doing the above.
        // ClientOptions = clients.Select(x => new SelectListItem
        // {
        //     Value = x.Id.ToString(),
        //     Text = x.ClientName
        // }).ToList();
    }

}