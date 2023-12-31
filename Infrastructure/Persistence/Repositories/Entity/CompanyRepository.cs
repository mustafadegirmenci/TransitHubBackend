using Application.Repositories.Entity;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Repositories.Common;

namespace Persistence.Repositories.Entity;

public class CompanyRepository : Repository<Company>, ICompanyRepository
{
    private ApplicationDbContext _context;
    
    public CompanyRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
    
    public async Task<Company?> GetCompanyByEmailAsync(string email)
    {
        return await _context.Companies.FirstOrDefaultAsync(u => u.Email == email);
    }
}