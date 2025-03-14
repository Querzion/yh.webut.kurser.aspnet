using System.Diagnostics;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Business.DTOs;
using Data.Interfaces;

namespace Business.Services;

public class ClientService(IClientRepository clientRepository) : IClientService
{
    private readonly IClientRepository _clientRepository = clientRepository;

    public async Task<IResult> AddClientAsync(ClientRegistrationForm registrationForm)
    {
        if (registrationForm == null)
            return Result.BadRequest("Invalid customer registration.");

        await _clientRepository.BeginTransactionAsync();

        try
        {
            var customerEntity = ClientFactory.CreateEntityFrom(registrationForm);

            if (await _clientRepository.AlreadyExistsAsync(x => x.ClientName == registrationForm.ClientName))
            {
                await _clientRepository.RollbackTransactionAsync();
                return Result.AlreadyExists("A Client with this name already exists.");
            }            
            
            var result = await _clientRepository.CreateAsync(customerEntity);

            if (result)
            {
                await _clientRepository.CommitTransactionAsync();
                return Result.Ok();
            }
            else
            {
                await _clientRepository.RollbackTransactionAsync();
                return Result.Error("Client could not be created.");
            }
        }
        catch (Exception ex)
        {
            await _clientRepository.RollbackTransactionAsync();
            Debug.WriteLine(ex.Message);
            return Result.Error(ex.Message);
        }
    }

    public Task<IResult> GetAllClientsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IResult> GetClientByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IResult> GetClientByNameAsync(string clientName)
    {
        throw new NotImplementedException();
    }

    public Task<IResult> UpdateClientAsync(int id, ClientUpdateForm updateForm)
    {
        throw new NotImplementedException();
    }

    public Task<IResult> DeleteClientAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IResult> CheckIfClientExists(string customerName)
    {
        throw new NotImplementedException();
    }
}