using Application.Repositories.Common;
using Domain.Entities;

namespace Application.Repositories.Entity;

public interface ICompanyRepository : IRepository<Company>
{
    public Task<Company?> GetCompanyByEmailAsync(string username);
}