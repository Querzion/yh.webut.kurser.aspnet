using System.Runtime.InteropServices.JavaScript;
using Data.Contexts;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Presentation.WebApp.Controllers;

public class ProjectsController(AppDbContext context) : Controller
{
    private readonly AppDbContext _context = context;

    public async Task<IActionResult> Index()
    {
        var project = await _context.Projects
            .Include(x => x.ProjectMembers)
            .ThenInclude(x => x.User)
            .FirstOrDefaultAsync(x => x.Id == "1");
        
        return View(project);
    }
    
    [HttpPost]
    public async Task<IActionResult> Add(ProjectEntity model, string selectedUserIds)
    {
        if (!ModelState.IsValid)
            return View("Index",model);

        var existingMembers = await _context.ProjectMembers
            .Where(m => m.ProjectId == model.Id)
            .ToListAsync();
        
        _context.ProjectMembers.RemoveRange(existingMembers);

        if (!string.IsNullOrEmpty(selectedUserIds))
        {
            var userIds = JsonSerializer.Deserialize<List<int>>(selectedUserIds);
            if (userIds != null)
            {
                foreach (var userId in userIds)
                {
                    _context.ProjectMembers.Add(new ProjectMemberEntity
                    {
                        ProjectId = model.Id, 
                        UserId = userId.ToString()
                    });
                }
            }
        }

        _context.Update(model);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index");
    }
}