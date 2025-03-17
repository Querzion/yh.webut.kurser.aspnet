using Presentation.WebApp.Data.Entities;

namespace Presentation.WebApp.Data.Repositories;

public class CustomerRepository(ApplicationDbContext context) : BaseRepository<CustomerEntity>(context);