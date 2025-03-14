using Business.DTOs;
using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class ClientFactory
{
    public static AddClientForm AddClient_RegistrationForm() => new();
    public static ClientRegistrationForm CreateRegistrationForm() => new();
    public static ClientUpdateForm CreateUpdateForm() => new();

    public static ClientRegistrationForm AddClientFrom(AddClientForm addClient) => new()
    {
        ClientName = addClient.ClientName,
        Email = addClient.Email,
        Location = addClient.Location,
        PhoneNumber = addClient.PhoneNumber
    };
    
    public static ClientEntity CreateEntityFrom(ClientRegistrationForm registrationForm) => new()
    {
        ClientName = registrationForm.ClientName,
        Email = registrationForm.Email,
        Location = registrationForm.Location,
        PhoneNumber = registrationForm.PhoneNumber
    };

    public static Client CreateOutputModel(ClientEntity entity) => new()
    {
        Id = entity.Id,
        ClientName = entity.ClientName
    };
    public static Client CreateOutputModelFrom(ClientEntity entity) => new()
    {
        Id = entity.Id,
        ClientName = entity.ClientName
    };

    public static ClientUpdateForm CreateUpdateFrom(Client customer) => new()
    {
        Id = customer.Id,
        ClientName = customer.ClientName
    };

    public static ClientEntity Update(ClientEntity customerEntity, ClientUpdateForm updateForm)
    {
        customerEntity.Id = customerEntity.Id;
        customerEntity.ClientName = updateForm.ClientName;
        
        return customerEntity;
    }
}