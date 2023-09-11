using Application.Repositories.Common;
using Domain.Entities;

namespace Application.Repositories.Entity;

public interface IUserRepository : IRepository<User>
{
    public Task<User?> GetUserByUsernameAsync(string username);
}