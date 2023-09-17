using Application.Features.Company.Authorization.Login;
using Application.Features.Company.Authorization.Register;
using Application.Features.Customer.Authorization.Login;
using Application.Features.Customer.Authorization.Register;
using Application.Repositories.Entity;
using Application.Services;
using Domain.Entities;
using Domain.Enums;

namespace Persistence.Services;

public class AuthService : IAuthService
{
    private readonly ICustomerRepository _customerRepository;
    private readonly ICompanyRepository _companyRepository;
    private readonly IHashingService _hashingService;
    private readonly ITokenService _tokenService;

    public AuthService(ICustomerRepository customerRepository, IHashingService hashingService, ITokenService tokenService, ICompanyRepository companyRepository)
    {
        _customerRepository = customerRepository;
        _hashingService = hashingService;
        _tokenService = tokenService;
        _companyRepository = companyRepository;
    }

    public async Task<RegisterCustomerResponse> RegisterCustomerAsync(string email, string password, string name, string surname)
    {
        if (await _customerRepository.GetCustomerByEmailAsync(email) is not null)
        {
            return new RegisterCustomerResponse
            {
                Token = null,
            };
        }

        var hashedPassword = _hashingService.Hash(password);

        var user = new Customer
        {
            Email = email,
            PasswordHash = hashedPassword,
            Name = name,
            Surname = surname,
            Role = UserRole.Customer,
            RegistrationDate = DateTimeOffset.Now
        };
        
        await _customerRepository.AddAsync(user);
        var loginResponse = await LoginCustomerAsync(email, password);

        return new RegisterCustomerResponse
        {
            Token = loginResponse.Token,
        };
    }
    
    public async Task<LoginCustomerResponse> LoginCustomerAsync(string email, string password)
    {
        var user = await _customerRepository.GetCustomerByEmailAsync(email);

        if (user is null)
        {
            return new LoginCustomerResponse
            {
                Token = null,
            };
        }
            
        var isPasswordValid = _hashingService.Verify(user.PasswordHash, password);

        if (!isPasswordValid)
        {
            return new LoginCustomerResponse
            {
                Token = null,
            };
        }

        return new LoginCustomerResponse
        {
            Token = _tokenService.GenerateToken(user),
        };
    }
    
    public async Task<RegisterCompanyResponse> RegisterCompanyAsync(string email, string password, string name, string foundDate)
    {
        if (await _companyRepository.GetCompanyByEmailAsync(email) is not null)
        {
            return new RegisterCompanyResponse
            {
                Token = null,
            };
        }

        var hashedPassword = _hashingService.Hash(password);

        var newCompany = new Company
        {
            Email = email,
            PasswordHash = hashedPassword,
            Name = name,
            FoundingDate = foundDate,
            Role = UserRole.Company,
            RegistrationDate = DateTimeOffset.Now
        };
        
        await _companyRepository.AddAsync(newCompany);
        var loginResponse = await LoginCompanyAsync(email, password);

        return new RegisterCompanyResponse
        {
            Token = loginResponse.Token,
        };
    }
    
    public async Task<LoginCompanyResponse> LoginCompanyAsync(string email, string password)
    {
        var company = await _companyRepository.GetCompanyByEmailAsync(email);

        if (company is null)
        {
            return new LoginCompanyResponse
            {
                Token = null,
            };
        }
            
        var isPasswordValid = _hashingService.Verify(company.PasswordHash, password);

        if (!isPasswordValid)
        {
            return new LoginCompanyResponse
            {
                Token = null,
            };
        }

        return new LoginCompanyResponse
        {
            Token = _tokenService.GenerateToken(company),
        };
    }
}