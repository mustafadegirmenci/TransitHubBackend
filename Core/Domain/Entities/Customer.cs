namespace Domain.Entities;

public class Customer : BaseUser
{
    public string Name { get; set; }
    public string Surname { get; set; }
}