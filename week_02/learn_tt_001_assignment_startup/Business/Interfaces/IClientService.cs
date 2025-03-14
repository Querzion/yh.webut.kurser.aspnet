using Business.DTOs;
using Business.Models;

namespace Business.Interfaces;

public interface IClientService
{
    Task<IResult> AddClientAsync(ClientRegistrationForm registrationForm);
    Task<IResult> GetAllClientsAsync();
    Task<IResult> GetClientByIdAsync(int id);
    Task<IResult> GetClientByNameAsync(string clientName);
    Task<IResult> UpdateClientAsync(int id, ClientUpdateForm updateForm);
    Task<IResult> DeleteClientAsync(int id);
    Task<IResult> CheckIfClientExists(string customerName);
}