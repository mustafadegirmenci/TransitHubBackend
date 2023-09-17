namespace Domain.Entities;

public class Company : BaseUser
{
    public string Name { get; set; }
    public string FoundingDate { get; set; }
}