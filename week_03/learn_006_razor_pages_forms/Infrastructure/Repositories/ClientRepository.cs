using Infrastructure.Contexts;
using Infrastructure.Entities;

namespace Infrastructure.Repositories;

public class ClientRepository(DataContext context) : BaseRepository<ClientEntity>(context)
{
    private readonly DataContext _context = context;
}