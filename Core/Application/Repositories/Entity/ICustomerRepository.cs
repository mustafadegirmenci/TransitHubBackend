using Application.Repositories.Common;
using Domain.Entities;

namespace Application.Repositories.Entity;

public interface ICustomerRepository : IRepository<Customer>
{
    public Task<Customer?> GetCustomerByEmailAsync(string username);
}