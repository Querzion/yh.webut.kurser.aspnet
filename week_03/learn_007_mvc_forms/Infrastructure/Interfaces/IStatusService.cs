using Infrastructure.DTOs;

namespace Infrastructure.Interfaces;

public interface IStatusService
{
    Task<IResult> CreateStatusAsync(StatusForm registrationForm);
    Task<IResult> GetAllStatusesAsync();
    Task<IResult> GetStatusByIdAsync(int id);
    Task<IResult> GetStatusByNameAsync(string statusName);
    Task<IResult> UpdateStatusAsync(int id, StatusUpdate updateForm);
    Task<IResult> DeleteStatusAsync(int id);
    Task<IResult> CheckIfStatusExists(string statusName);
}