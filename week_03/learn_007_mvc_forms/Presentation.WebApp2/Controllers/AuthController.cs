using Microsoft.AspNetCore.Mvc;
using Presentation.WebApp2.Models;

namespace Presentation.WebApp2.Controllers;

public class AuthController : Controller
{
    public IActionResult SignUp()
    {
        // This is used later on to save the password entry without deleting it from the form.
        var formData = new SignUpFormModel();
        return View(formData);

        // return View();
    }
    
    [HttpPost]
    public IActionResult SignUp(SignUpFormModel formData)
    {
        if (!ModelState.IsValid)
            return View(formData);
        
        return View();
    }
}