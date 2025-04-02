using Business.Services;
using Domain.DTOs;
using Domain.Extensions;
using Microsoft.AspNetCore.Mvc;
using Presentation.WebApp.ViewModels;
using Presentation.WebApp.ViewModels.Adds;
using Presentation.WebApp.ViewModels.Edits;

namespace Presentation.WebApp.Controllers;

public class ProjectsController(IProjectService projectService) : Controller
{
    private readonly IProjectService _projectService = projectService;

    public async Task<IActionResult> Index()
    {
        var model = new ProjectsViewModel
        {
            // Projects = await _projectService.GetProjectsAsync(),
        };
        
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Add(AddProjectViewModel model)
    {
        var addProjectFormData = model.MapTo<AddProjectFormData>();
        var result = await _projectService.CreateProjectAsync(addProjectFormData);
        
        return Json(new { });
    }
    
    [HttpPost]
    public IActionResult Update(EditProjectViewModel model)
    {
        return Json(new { });
    }
    
    [HttpPost]
    public IActionResult Delete(string id)
    {
        return Json(new { });
    }
}