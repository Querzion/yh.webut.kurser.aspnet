using Infrastructure.DTOs;

namespace Infrastructure.Interfaces;

public interface IProjectService
{
    Task<IResult> CreateProjectAsync(ProjectForm registrationForm);
    Task<IResult> GetAllProjectsAsync();
    Task<IResult> GetProjectByIdAsync(int id);
    Task<IResult> GetProjectByNameAsync(string projectName);
    Task<IResult> UpdateProjectAsync(int id, ProjectUpdate updateForm);
    Task<IResult> DeleteProjectAsync(int id);
    Task<IResult> CheckIfProjectExists(string projectName);
}