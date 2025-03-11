using Infrastructure.DTOs;
using Infrastructure.Repositories;

namespace Infrastructure.Services;

public class ClientService(ClientRepository clientRepository)
{
    private readonly ClientRepository _clientRepository = clientRepository;


}