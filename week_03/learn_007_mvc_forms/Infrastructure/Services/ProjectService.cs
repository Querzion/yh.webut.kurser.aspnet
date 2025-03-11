using System.Diagnostics;
using Infrastructure.DTOs;
using Infrastructure.Factories;
using Infrastructure.Interfaces;
using Infrastructure.Models;
using Infrastructure.Repositories;

namespace Infrastructure.Services;

public class ProjectService(ProjectRepository projectRepository) : IProjectService
{
    private readonly ProjectRepository _projectRepository = projectRepository;
    
    
    public async Task<IResult> CreateProjectAsync(ProjectForm registrationForm)
    {
        if (registrationForm == null)
            return Result.BadRequest("Invalid project registration.");
        
        await _projectRepository.BeginTransactionAsync();
        
        try
        {
            var projectEntity = ProjectFactory.CreateEntityFrom(registrationForm);

            if (await _projectRepository.AlreadyExistsAsync(x => x.Title == registrationForm.Title))
            {
                await _projectRepository.RollbackTransactionAsync();
                return Result.AlreadyExists("A Project with that Title already exists.");
            }
            
            var result = await _projectRepository.CreateAsync(projectEntity);

            if (result)
            {
                await _projectRepository.CommitTransactionAsync();
                return Result.Ok();
            }
            else
            {
                await _projectRepository.RollbackTransactionAsync();
                return Result.Error($"Failed to create project.");
            }
        }
        catch (Exception ex)
        {
            await _projectRepository.RollbackTransactionAsync();
            Debug.WriteLine(ex.Message);
            return Result.Error(ex.Message);
        }
    }

    public async Task<IResult> GetAllProjectsAsync()
    {
        var projects = await _projectRepository.GetAllAsync();
        var project = projects?.Select(ProjectFactory.CreateOutputModel);
        return Result<IEnumerable<Project>>.Ok(project);
    }

    public async Task<IResult> GetProjectByIdAsync(int id)
    {
        var projectEntity = await _projectRepository.GetAsync(x => x.Id == id);
        if (projectEntity == null)
            return Result.NotFound("Project not found.");
        
        var project = ProjectFactory.CreateOutputModelFrom(projectEntity);
        
        return Result<Project>.Ok(project);
    }

    public async Task<IResult> GetProjectByNameAsync(string projectName)
    {
        var projectEntity = await _projectRepository.GetAsync(x => x.Title == projectName);
        if (projectEntity == null)
            return Result.NotFound("Project not found.");
        
        var project = ProjectFactory.CreateOutputModelFrom(projectEntity);
        
        return Result<Project>.Ok(project);
    }

    public async Task<IResult> UpdateProjectAsync(int id, ProjectUpdate updateForm)
    {
        await _projectRepository.BeginTransactionAsync();
        
        try
        {
            var projectEntity = await _projectRepository.GetAsync(x => x.Id == id);
            if (projectEntity == null)
            {
                await _projectRepository.RollbackTransactionAsync();
                return Result.NotFound("Project not found.");
            }
            
            projectEntity = ProjectFactory.Update(projectEntity, updateForm);
            
            var result = await _projectRepository.UpdateAsync(projectEntity);

            if (result)
            {
                await _projectRepository.CommitTransactionAsync();
                return Result.Ok();
            }
            else
            {
                await _projectRepository.RollbackTransactionAsync();
                return Result.Error($"Failed to update project.");
            }
        }
        catch (Exception ex)
        {
            await _projectRepository.RollbackTransactionAsync();
            Debug.WriteLine(ex.Message);
            return Result.Error(ex.Message);
        }
    }

    public async Task<IResult> DeleteProjectAsync(int id)
    {
        var projectEntity = await _projectRepository.GetAsync(x => x.Id == id);
        if (projectEntity == null)
            return Result.NotFound("Project not found.");
        
        try
        {
            var result = await _projectRepository.DeleteAsync(projectEntity);
            return result ? Result.Ok() : Result.Error("Project was not deleted.");
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return Result.Error(ex.Message);
        }
    }

    public async Task<IResult> CheckIfProjectExists(string projectName)
    {
        var entity = await _projectRepository.GetAsync(x => x.Title == projectName);
        if (entity == null)
            return Result.NotFound("Project not found.");
        
        try
        {
            var project = ProjectFactory.CreateOutputModelFrom(entity);
            return Result<Project>.Ok(project);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return Result.Error(ex.Message);
        }
    }
}