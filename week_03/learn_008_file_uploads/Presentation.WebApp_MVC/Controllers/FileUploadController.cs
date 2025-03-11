using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Presentation.WebApp_MVC.Models;

namespace Presentation.WebApp_MVC.Controllers;

public class FileUploadController(IWebHostEnvironment env) : Controller
{
    private readonly IWebHostEnvironment _env = env;

    public IActionResult Upload()
    {
        return View();
    }

    #region Teachers Version - Direct upload (No NameChange)
    
        // [HttpPost]
        // public async Task<IActionResult> Upload(FileUploadViewModel model)
        // {
        //     if (!ModelState.IsValid || model.File == null || model.File.Length == 0)
        //         return View(model);
        //
        //     // if (!ModelState.IsValid || model.File == null || model.File.Length == 0)
        //     // {
        //     //     // File = File from 'FileUploadViewModel'. This error message can be added here, or in the model. 
        //     //     ModelState.AddModelError("File", "You must provide a file for uploading.");
        //     //     return View(model);
        //     // }
        //
        //     var uploadFolder = Path.Combine(_env.WebRootPath, "uploads");
        //     Directory.CreateDirectory(uploadFolder);
        //
        //     var filePath = Path.Combine(uploadFolder, $"{Guid.NewGuid()}_{Path.GetFileName(model.File.FileName)}");
        //
        //     using (var stream = new FileStream(filePath, FileMode.Create))
        //     {
        //         await model.File.CopyToAsync(stream);
        //     }
        //
        //     ViewBag.Message = "File uploaded successfully.";
        //
        //     return View();
        // }
        
    #endregion

    #region ChatGPT Version - Date.GUID.Extension
        // 2025-03-11.a1b2c3d4-e5f6-7890-g123-h4567890abcd.jpg

        // [HttpPost]
        // public async Task<IActionResult> Upload(FileUploadViewModel model)
        // {
        //     if (!ModelState.IsValid || model.File == null || model.File.Length == 0)
        //         return View(model);
        //     
        //     var uploadFolder = Path.Combine(_env.WebRootPath, "uploads");
        //     Directory.CreateDirectory(uploadFolder);
        //     
        //     // Get the file extension
        //     var fileExtension = Path.GetExtension(model.File.FileName);
        //
        //     // Generate the new filename in the format: [todaysdate].guid-id.extension
        //     var newFileName = $"{DateTime.UtcNow:yyyy-MM-dd}.{Guid.NewGuid()}{fileExtension}";
        //     
        //     var filePath = Path.Combine(uploadFolder, newFileName);
        //     
        //     await using (var stream = new FileStream(filePath, FileMode.Create))
        //     {
        //         await model.File.CopyToAsync(stream);
        //     }
        //     
        //     ViewBag.Message = $"File uploaded successfully as {newFileName}.";
        //     
        //     return View();
        // }
    
    #endregion
    
    #region ChatGPT Version - Date.UserId.GUID.Extension
        // [2025-03-11].[ID-0].[a1b2c3d4-e5f6-7890-g123-h4567890abcd].jpg
    
        [HttpPost]
        public async Task<IActionResult> Upload(FileUploadViewModel model)
        {
            if (!ModelState.IsValid || model.File == null || model.File.Length == 0)
                return View(model);
        
            var uploadFolder = Path.Combine(_env.WebRootPath, "uploads");
            Directory.CreateDirectory(uploadFolder);
            
            // Get the file extension
            var fileExtension = Path.GetExtension(model.File.FileName);
            
            // Example: Get the User ID (You may get it from authentication or pass it via the model)
            var userId = User.Identity.IsAuthenticated ? User.FindFirst(ClaimTypes.NameIdentifier)?.Value : "0"; // Default to "0" if not authenticated
            
            // Generate the new filename in the format: [YYYY-MM-DD].[ID-UserID].[GUID].extension
            var newFileName = $"[{DateTime.UtcNow:yyyy-MM-dd}].[ID-{userId}].[{Guid.NewGuid()}]{fileExtension}";
            
            var filePath = Path.Combine(uploadFolder, newFileName);
            
            await using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await model.File.CopyToAsync(stream);
            }
            
            ViewBag.Message = $"File uploaded successfully as {newFileName}.";
            
            return View();
        }
    
    #endregion
}