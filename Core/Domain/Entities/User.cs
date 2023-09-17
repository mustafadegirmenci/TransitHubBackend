using Domain.Common;
using Domain.Enums;

namespace Domain.Entities;

public abstract class BaseUser : BaseEntity
{
    public string Email { get; set; }
    public string PasswordHash { get; set; }

    public DateTimeOffset RegistrationDate { get; set; }
    public UserRole Role { get; set; }
}