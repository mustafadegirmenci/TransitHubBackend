using Application.Features.Company.Authorization.Login;
using Application.Features.Company.Authorization.Register;
using Application.Features.Customer.Authorization.Login;
using Application.Features.Customer.Authorization.Register;

namespace Application.Services;

public interface IAuthService
{
    public Task<RegisterCustomerResponse> RegisterCustomerAsync(string username, string password, string name, string surname);
    public Task<LoginCustomerResponse> LoginCustomerAsync(string email, string password);
    
    public Task<RegisterCompanyResponse> RegisterCompanyAsync(string username, string password, string name, string foundDate);
    public Task<LoginCompanyResponse> LoginCompanyAsync(string username, string password);
}