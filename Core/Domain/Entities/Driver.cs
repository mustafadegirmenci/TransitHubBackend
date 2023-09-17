using Domain.Common;

namespace Domain.Entities;

public class Driver : BaseEntity
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public int ExperienceInYears { get; set; }

    public int CompanyId { get; set; }
}