using Infrastructure.DTOs;

namespace Infrastructure.Interfaces;

public interface IClientService
{
    Task<IResult> CreateClientAsync(ClientForm registrationForm);
    Task<IResult> GetAllClientsAsync();
    Task<IResult> GetClientByIdAsync(int id);
    Task<IResult> GetClientByNameAsync(string customerName);
    Task<IResult> UpdateClientAsync(int id, ClientUpdate updateForm);
    Task<IResult> DeleteClientAsync(int id);
    Task<IResult> CheckIfClientExists(string customerName);
}