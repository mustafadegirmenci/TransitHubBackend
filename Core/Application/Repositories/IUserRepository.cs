using Application.Repositories.Common;
using Domain.Entities;

namespace Application.Repositories;

public interface IUserRepository : IRepository<User>
{
    public Task<User?> GetUserByUsernameAsync(string username);
}