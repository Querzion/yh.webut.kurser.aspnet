using System.Diagnostics;
using Infrastructure.DTOs;
using Infrastructure.Factories;
using Infrastructure.Interfaces;
using Infrastructure.Models;
using Infrastructure.Repositories;

namespace Infrastructure.Services;

public class ClientService(ClientRepository clientRepository) : IClientService
{
    private readonly ClientRepository _clientRepository = clientRepository;
    
    
    public async Task<IResult> CreateClientAsync(ClientForm registrationForm)
    {
        if (registrationForm == null)
            return Result.BadRequest("Invalid client registration.");
        
        await _clientRepository.BeginTransactionAsync();
        
        try
        {
            var clientEntity = ClientFactory.CreateEntityFrom(registrationForm);

            if (await _clientRepository.AlreadyExistsAsync(x => x.ClientName == registrationForm.ClientName))
            {
                await _clientRepository.RollbackTransactionAsync();
                return Result.AlreadyExists("A Client with that Title already exists.");
            }
            
            var result = await _clientRepository.CreateAsync(clientEntity);

            if (result)
            {
                await _clientRepository.CommitTransactionAsync();
                return Result.Ok();
            }
            else
            {
                await _clientRepository.RollbackTransactionAsync();
                return Result.Error($"Failed to create client.");
            }
        }
        catch (Exception ex)
        {
            await _clientRepository.RollbackTransactionAsync();
            Debug.WriteLine(ex.Message);
            return Result.Error(ex.Message);
        }
    }

    public async Task<IResult> GetAllClientsAsync()
    {
        var clients = await _clientRepository.GetAllAsync();
        var client = clients?.Select(ClientFactory.CreateOutputModel);
        return Result<IEnumerable<Client>>.Ok(client);
    }

    public async Task<IResult> GetClientByIdAsync(int id)
    {
        var clientEntity = await _clientRepository.GetAsync(x => x.Id == id);
        if (clientEntity == null)
            return Result.NotFound("Client not found.");
        
        var client = ClientFactory.CreateOutputModelFrom(clientEntity);
        
        return Result<Client>.Ok(client);
    }

    public async Task<IResult> GetClientByNameAsync(string clientName)
    {
        var clientEntity = await _clientRepository.GetAsync(x => x.ClientName == clientName);
        if (clientEntity == null)
            return Result.NotFound("Client not found.");
        
        var client = ClientFactory.CreateOutputModelFrom(clientEntity);
        
        return Result<Client>.Ok(client);
    }

    public async Task<IResult> UpdateClientAsync(int id, ClientUpdate updateForm)
    {
        await _clientRepository.BeginTransactionAsync();
        
        try
        {
            var clientEntity = await _clientRepository.GetAsync(x => x.Id == id);
            if (clientEntity == null)
            {
                await _clientRepository.RollbackTransactionAsync();
                return Result.NotFound("Client not found.");
            }
            
            clientEntity = ClientFactory.Update(clientEntity, updateForm);
            
            var result = await _clientRepository.UpdateAsync(clientEntity);

            if (result)
            {
                await _clientRepository.CommitTransactionAsync();
                return Result.Ok();
            }
            else
            {
                await _clientRepository.RollbackTransactionAsync();
                return Result.Error($"Failed to update client.");
            }
        }
        catch (Exception ex)
        {
            await _clientRepository.RollbackTransactionAsync();
            Debug.WriteLine(ex.Message);
            return Result.Error(ex.Message);
        }
    }

    public async Task<IResult> DeleteClientAsync(int id)
    {
        var clientEntity = await _clientRepository.GetAsync(x => x.Id == id);
        if (clientEntity == null)
            return Result.NotFound("Client not found.");
        
        try
        {
            var result = await _clientRepository.DeleteAsync(clientEntity);
            return result ? Result.Ok() : Result.Error("Client was not deleted.");
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return Result.Error(ex.Message);
        }
    }

    public async Task<IResult> CheckIfClientExists(string clientName)
    {
        var entity = await _clientRepository.GetAsync(x => x.ClientName == clientName);
        if (entity == null)
            return Result.NotFound("Client not found.");
        
        try
        {
            var client = ClientFactory.CreateOutputModelFrom(entity);
            return Result<Client>.Ok(client);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return Result.Error(ex.Message);
        }
    }
}