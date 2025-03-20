using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Presentation.WebApp.Models;
using Presentation.WebApp.Services;

namespace Presentation.WebApp.Controllers;

public class AuthController(UserService userService, SignInManager<ApplicationUser> signInManager) : Controller
{
    private readonly UserService _userService = userService;
    private readonly SignInManager<ApplicationUser> _signInManager = signInManager;

    // [Route("register")]
    public IActionResult SignUp()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> SignUp(UserSignUpForm form)
    {
        if (!ModelState.IsValid)
            return View(form);

        if (await _userService.ExistsAsync(form.Email))
        {
            ModelState.AddModelError("Exists", "User already exists.");
            return View(form);
        }
        
        var result = await _userService.CreateAsync(form);
        if (result)
            return RedirectToAction("SignIn", "Auth");
        
        ModelState.AddModelError("Not Created", "User was not created.");
        return View(form);
    }
    
    // [Route("login")]
    public IActionResult SignIn(string returnUrl = "/")
    {
        ViewBag.ReturnUrl = returnUrl;
        ViewBag.ErrorMessage = "";
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> SignIn(UserSignInForm form, string returnUrl = "/")
    {
        #region With the returnUrl (Valid)

            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(form.Email, form.Password, false, false);
                if (result.Succeeded)
                {
                    if (Url.IsLocalUrl(returnUrl))
                        return Redirect(returnUrl);
                    
                    return RedirectToAction("Index", "Home");
                }
            }
                
            ViewBag.ReturnUrl = returnUrl;
            ViewBag.ErrorMessage = "Invalid email or password.";
            return View(form);

        #endregion
        
        #region With the returnUrl (Not Valid)

            // if (!ModelState.IsValid)
            // {
            //     ViewBag.ReturnUrl = returnUrl;
            //     ViewBag.ErrorMessage = "Invalid email or password.";
            //     return View(form);
            // }
            //
            // var result = await _signInManager.PasswordSignInAsync(form.Email, form.Password, false, false);
            // if (result.Succeeded)
            // {
            //     if (Url.IsLocalUrl(returnUrl))
            //         return Redirect(returnUrl);
            //     
            //     return RedirectToAction("Index", "Home");
            // }
            //
            // ViewBag.ReturnUrl = returnUrl;
            // ViewBag.ErrorMessage = "Invalid email or password.";
            // return View(form);

        #endregion
        
        #region Without the returnUrl

            // if (ModelState.IsValid)
            // {
            //     var result = await _signInManager.PasswordSignInAsync(form.Email, form.Password, false, false);
            //     if (result.Succeeded)
            //         return RedirectToAction("Index", "Home");
            // }
            //
            // ViewData["ErrorMessage"] = "Invalid login attempt.";
            // return View(form);

        #endregion
    }
    
    public new async Task<IActionResult> SignOut()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }
    
    // Gets status codes from the UserService.cs if it returns an int
    // [HttpPost]
    // public async Task<IActionResult> SignUp(UserSignUpForm form)
    // {
    //     if (!ModelState.IsValid)
    //         return View(form);
    //     
    //     var result = await _userService.CreateAsync(form);
    //     switch (result)
    //     {
    //         case 201:
    //             return RedirectToAction("SignIn", "Auth");
    //         
    //         case 400:
    //         {
    //             ModelState.AddModelError("Invalid Fields", "Required fields not valid.");
    //             return View(form);
    //         }
    //         
    //         case 409:
    //         {
    //             ModelState.AddModelError("Exists", "User already exists.");
    //             return View(form);
    //         }
    //         
    //         default:
    //         {
    //             ModelState.AddModelError("Unexpected Error", "An unexpected error occured.");
    //             return View(form);
    //         }
    //     }
    // }
}