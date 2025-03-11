using Infrastructure.Models;
using Infrastructure.Entities;
using Infrastructure.DTOs;

namespace Infrastructure.Factories;

public static class ProjectFactory
{
    public static ProjectForm CreateRegistrationForm() => new();
    public static ProjectUpdate CreateUpdateForm() => new();

    // Create a new ProjectEntity based of the ProjectRegistrationForm, linked as form.
    public static ProjectEntity CreateEntityFrom(ProjectForm form) => new()
    {
        Title = form.Title,
        Description = form.Description,
        StartDate = form.StartDate,
        EndDate = form.EndDate,
        ClientId = form.ClientId,
        StatusId = form.StatusId,
    };
    public static ProjectForm CreateOutputModel(ProjectEntity entity) => new()
    {
        Id = entity.Id,
        Title = entity.Title,
        Description = entity.Description,
        StartDate = entity.StartDate,
        EndDate = entity.EndDate,
        ClientId = entity.ClientId,
        StatusId = entity.StatusId
    };
    public static ProjectForm CreateOutputModelFrom(ProjectEntity entity) => new()
    {
        Id = entity.Id,
        Title = entity.Title,
        Description = entity.Description,
        StartDate = entity.StartDate,
        EndDate = entity.EndDate,
        ClientId = entity.ClientId,
        StatusId = entity.StatusId
    };

    public static ProjectUpdate CreateUpdateForm(Project project) => new()
    {
        Id = project.Id,
        Title = project.Title,
        Description = project.Description,
        StartDate = project.StartDate,
        EndDate = project.EndDate,
        ClientId = project.ClientId,
        StatusId = project.StatusId,

    };
    
    public static ProjectEntity Update(ProjectEntity projectEntity, ProjectUpdate updateForm)
    {
        projectEntity.Id = projectEntity.Id;
        projectEntity.Title = updateForm.Title;
        projectEntity.Description = updateForm.Description;
        projectEntity.StartDate = updateForm.StartDate;
        projectEntity.EndDate = updateForm.EndDate;
        projectEntity.ClientId = updateForm.ClientId;
        projectEntity.StatusId = updateForm.StatusId;
        
        return projectEntity;
    }
}
