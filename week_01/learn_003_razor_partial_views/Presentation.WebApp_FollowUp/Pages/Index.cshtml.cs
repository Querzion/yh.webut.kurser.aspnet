using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Presentation.WebApp_FollowUp.Models;

namespace Presentation.WebApp_FollowUp.Pages;

public class IndexModel : PageModel
{
    public List<User> Users { get; set; } = [];
    
    public void OnGet()
    {
        Users =
        [
            new User { Id = 1, FirstName = "John", LastName = "Doe", Email = "x@x.xx"},
            new User { Id = 2, FirstName = "Jane", LastName = "Doe", Email = "jane@x.xx"},
            new User { Id = 3, FirstName = "Mary", LastName = "Doe", Email = "mary@x.xx" },
            new User { Id = 4, FirstName = "Sam", LastName = "Doe", Email = "sam@x.xx" },
            new User { Id = 5, FirstName = "Slisk", LastName = "Lindqvist", Email = "slisk.lindqvist@querzion.com" }
        ];
    }
}