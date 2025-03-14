using Microsoft.AspNetCore.Mvc.Rendering;

namespace Presentation.WebApp.Models;

// public class SignUpViewModel(ClientService clientService)
// {
//     private readonly ClientService _clientService = clientService;
//     
//     public SignUpFormModel FormData { get; set; } = new();
//     public List<SelectListItem> ClientOptions { get; set; } = new();
//
//     public async Task PopulateClientOptionsAsync()
//     {
//
//         #region ChatGPT generated code
//
//         var result = await _clientService.GetAllClientsAsync();
//             
//         if (!result.Success)
//         {
//             // Handle error (logging, showing a message, etc.)
//             return;
//         }
//
//         var clients = (result as Result<IEnumerable<Client>>)?.Data ?? [];
//
//         #endregion
//
//         ClientOptions =
//         [
//             ..clients.Select(x => new SelectListItem
//             {
//                 Value = x.Id.ToString(),
//                 Text = x.ClientName
//             })
//         ];
//     }
//
//     // Method to clear the form.
//     public void ClearFormData() => FormData = new();
// }