using Infrastructure.DTOs;
using Infrastructure.Entities;
using Infrastructure.Models;

namespace Infrastructure.Factories;

public class ClientFactory
{
    public static ClientForm CreateRegistrationForm() => new();
    public static ClientUpdate CreateUpdateForm() => new();

    public static ClientEntity CreateEntityFrom(ClientForm registrationForm) => new()
    {
        ClientName = registrationForm.ClientName
    };

    public static ClientForm CreateOutputModel(ClientEntity entity) => new()
    {
        Id = entity.Id,
        ClientName = entity.ClientName
    };
    public static ClientForm CreateOutputModelFrom(ClientEntity entity) => new()
    {
        Id = entity.Id,
        ClientName = entity.ClientName
    };

    public static ClientUpdate CreateUpdateForm(Client client) => new()
    {
        Id = client.Id,
        ClientName = client.ClientName
    };

    public static ClientEntity Update(ClientEntity clientEntity, ClientUpdate updateForm)
    {
        clientEntity.Id = clientEntity.Id;
        clientEntity.ClientName = updateForm.ClientName;
        
        return clientEntity;
    }
}