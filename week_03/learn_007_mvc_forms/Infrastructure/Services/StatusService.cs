using System.Diagnostics;
using Infrastructure.DTOs;
using Infrastructure.Factories;
using Infrastructure.Interfaces;
using Infrastructure.Models;
using Infrastructure.Repositories;

namespace Infrastructure.Services;

public class StatusService(StatusRepository statusRepository) : IStatusService
{
    private readonly StatusRepository _statusRepository = statusRepository;
    
    
    public async Task<IResult> CreateStatusAsync(StatusForm registrationForm)
    {
        if (registrationForm == null)
            return Result.BadRequest("Invalid status registration.");
        
        await _statusRepository.BeginTransactionAsync();
        
        try
        {
            var statusEntity = StatusFactory.CreateEntityFrom(registrationForm);

            if (await _statusRepository.AlreadyExistsAsync(x => x.StatusName == registrationForm.StatusName))
            {
                await _statusRepository.RollbackTransactionAsync();
                return Result.AlreadyExists("A Status with that Title already exists.");
            }
            
            var result = await _statusRepository.CreateAsync(statusEntity);

            if (result)
            {
                await _statusRepository.CommitTransactionAsync();
                return Result.Ok();
            }
            else
            {
                await _statusRepository.RollbackTransactionAsync();
                return Result.Error($"Failed to create status.");
            }
        }
        catch (Exception ex)
        {
            await _statusRepository.RollbackTransactionAsync();
            Debug.WriteLine(ex.Message);
            return Result.Error(ex.Message);
        }
    }

    public async Task<IResult> GetAllStatusesAsync()
    {
        var statuses = await _statusRepository.GetAllAsync();
        var status = statuses?.Select(StatusFactory.CreateOutputModel);
        return Result<IEnumerable<Status>>.Ok(status);
    }

    public async Task<IResult> GetStatusByIdAsync(int id)
    {
        var statusEntity = await _statusRepository.GetAsync(x => x.Id == id);
        if (statusEntity == null)
            return Result.NotFound("Status not found.");
        
        var status = StatusFactory.CreateOutputModelFrom(statusEntity);
        
        return Result<Status>.Ok(status);
    }

    public async Task<IResult> GetStatusByNameAsync(string statusName)
    {
        var statusEntity = await _statusRepository.GetAsync(x => x.StatusName == statusName);
        if (statusEntity == null)
            return Result.NotFound("Status not found.");
        
        var status = StatusFactory.CreateOutputModelFrom(statusEntity);
        
        return Result<Status>.Ok(status);
    }

    public async Task<IResult> UpdateStatusAsync(int id, StatusUpdate updateForm)
    {
        await _statusRepository.BeginTransactionAsync();
        
        try
        {
            var statusEntity = await _statusRepository.GetAsync(x => x.Id == id);
            if (statusEntity == null)
            {
                await _statusRepository.RollbackTransactionAsync();
                return Result.NotFound("Status not found.");
            }
            
            statusEntity = StatusFactory.Update(statusEntity, updateForm);
            
            var result = await _statusRepository.UpdateAsync(statusEntity);

            if (result)
            {
                await _statusRepository.CommitTransactionAsync();
                return Result.Ok();
            }
            else
            {
                await _statusRepository.RollbackTransactionAsync();
                return Result.Error($"Failed to update status.");
            }
        }
        catch (Exception ex)
        {
            await _statusRepository.RollbackTransactionAsync();
            Debug.WriteLine(ex.Message);
            return Result.Error(ex.Message);
        }
    }

    public async Task<IResult> DeleteStatusAsync(int id)
    {
        var statusEntity = await _statusRepository.GetAsync(x => x.Id == id);
        if (statusEntity == null)
            return Result.NotFound("Status not found.");
        
        try
        {
            var result = await _statusRepository.DeleteAsync(statusEntity);
            return result ? Result.Ok() : Result.Error("Status was not deleted.");
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return Result.Error(ex.Message);
        }
    }

    public async Task<IResult> CheckIfStatusExists(string statusName)
    {
        var entity = await _statusRepository.GetAsync(x => x.StatusName == statusName);
        if (entity == null)
            return Result.NotFound("Status not found.");
        
        try
        {
            var status = StatusFactory.CreateOutputModelFrom(entity);
            return Result<Status>.Ok(status);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return Result.Error(ex.Message);
        }
    }
}