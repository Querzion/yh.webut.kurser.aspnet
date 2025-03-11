using Infrastructure.DTOs;

namespace Infrastructure.Interfaces;

public interface IStatusService
{
    Task<IResult> CreateStatusTypeAsync(StatusForm registrationForm);
    Task<IResult> GetAllStatusTypesAsync();
    Task<IResult> GetStatusTypeByIdAsync(int id);
    Task<IResult> GetStatusByStatusNameAsync(string statusName);
    Task<IResult> UpdateStatusTypeAsync(int id, StatusUpdate updateForm);
    Task<IResult> DeleteStatusTypeAsync(int id);
    Task<IResult> CheckIfStatusExists(string statusName);
}