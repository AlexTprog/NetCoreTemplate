namespace NetCoreTemplate.Domain.Users;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<User[]> GetAll();
    void Add(User user);
}