using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presentation.WebApp.Pages;

public class IndexModel : PageModel
{
    public List<string> Items { get; set; } = [];

    public void OnGet()
    {
        Items =
        [
            "Item 1",
            "Item 2",
            "Item 3",
            "Item 4",
            "Item 5"
        ];
    }
}