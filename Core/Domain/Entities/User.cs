using Domain.Common;

namespace Domain.Entities;

public class User : BaseEntity
{
    public string Username { get; set; }
    public string PasswordHash { get; set; }
    
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTimeOffset RegistrationDate { get; set; }
    
    public ICollection<Chat> Chats { get; set; }
    public ICollection<Request> Requests { get; set; }
}