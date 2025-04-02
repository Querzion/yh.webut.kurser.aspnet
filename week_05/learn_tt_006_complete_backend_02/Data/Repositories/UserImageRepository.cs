
using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Domain.Models;

namespace Data.Repositories;

public class UserImageRepository(AppDbContext context) : BaseRepository<UserImageEntity, UserImage>(context), IUserImageRepository
{
    
}

