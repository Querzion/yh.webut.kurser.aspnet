using Infrastructure.Contexts;
using Infrastructure.Entities;

namespace Infrastructure.Repositories;

public class StatusRepository(DataContext context) : BaseRepository<StatusEntity>(context)
{
    private readonly DataContext _context = context;
}