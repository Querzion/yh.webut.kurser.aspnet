using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Presentation.WebApp2.Models;

namespace Presentation.WebApp2.Controllers;

public class AuthController(ClientService clientService) : Controller
{
    // CONFUSE ME MORE!! THANK YOU FOR CHANGING THE CODE 5 TIMES IN ONE HOUR!
    // This is solely or mostly used in order to hold the password in the form at registration.
    // Seems stupid to use and to be a security risk, BUT it also has some features to it!
    // By making this viewmodel, the code may be cleaned up a bit.
    private readonly SignUpViewModel _signUpViewModel = new(clientService);
    // Register a service to add formData to!
    // private readonly AccountService _accountService;
    
    public async Task<IActionResult> SignUp()
    {
        // Creates a model at signup so that one can gain access to the variables at start.
        // var formData = new SignUpFormModel();
        // return View(formData);

        // Get information when in use
        await _signUpViewModel.PopulateClientOptionsAsync();
        
        return View(_signUpViewModel);

        // return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> SignUp(SignUpFormModel formData)
    {
        // if (!ModelState.IsValid && formData.ClientId == 0)
        if (!ModelState.IsValid)
        {
            await _signUpViewModel.PopulateClientOptionsAsync();
            _signUpViewModel.FormData = formData;
            return View(_signUpViewModel);
        }

        // And when the form is populated properly,
        // it starts a save to database command. Like this.
        // await _accountService.CreateUserAccountAsync(formData);
        
        // Empty all input fields. Set to empty form.
        _signUpViewModel.ClearFormData();
        return View(_signUpViewModel);
        
        // return View();
    }
}