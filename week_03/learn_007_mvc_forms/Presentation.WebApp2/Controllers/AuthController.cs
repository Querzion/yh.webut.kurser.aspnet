using Microsoft.AspNetCore.Mvc;
using Presentation.WebApp2.Models;

namespace Presentation.WebApp2.Controllers;

public class AuthController : Controller
{
    // CONFUSE ME MORE!! THANK YOU FOR CHANGING THE CODE 5 TIMES IN ONE HOUR!
    // This is solely or mostly used in order to hold the password in the form at registration.
    // Seems stupid to use and to be a security risk, BUT it also has some features to it!
    // By making this viewmodel, the code may be cleaned up a bit.
    private SignUpViewModel _signUpViewModel = new();
    
    public IActionResult SignUp()
    {
        // Creates a model at signup so that one can gain access to the variables at start.
        // var formData = new SignUpFormModel();
        // return View(formData);

        return View(_signUpViewModel);

        // return View();
    }
    
    [HttpPost]
    public IActionResult SignUp(SignUpFormModel formData)
    {
        // if (!ModelState.IsValid && formData.ClientId == 0)
        if (!ModelState.IsValid)
        {
            _signUpViewModel.FormData = formData;
            return View(_signUpViewModel);
        }

        return View();
    }
}