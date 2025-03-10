using Infrastructure.DTOs;
using Infrastructure.Entities;
using Infrastructure.Interfaces;
using Infrastructure.Models;
using Infrastructure.Repositories;

namespace Infrastructure.Services;

public class ClientService(ClientRepository clientRepository)
{
    private readonly ClientRepository _clientRepository = clientRepository;


    public async Task<IResult> GetClientsAsync()
    {
        // Get all client entities from the repository
        var clientEntities = await _clientRepository.GetAllAsync();
    
        // If no clients are found, return a not found result
        if (clientEntities == null || !clientEntities.Any())
        {
            return Result.NotFound("No clients found.");
        }
    
        // Map client entities to client DTOs or output models
        var clients = clientEntities.Select(entity => new Client
        {
            Id = entity.Id,
            ClientName = entity.ClientName,
            // If there are any other properties to map, add them here
            // For example: Projects = entity.Projects.Select(p => new ProjectDto { ... })
        });

        // Return the result as a successful operation with the mapped clients
        return Result<IEnumerable<Client>>.Ok(clients);
    }
}
