using CleanArchitecture.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using NetCoreTemplate.Domain.Users;


namespace NetCoreTemplate.Infrastructure.Repositories;

internal sealed class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public Task<User[]> GetAll()
    {
        return DbContext.Set<User>().ToArrayAsync();
    }
}