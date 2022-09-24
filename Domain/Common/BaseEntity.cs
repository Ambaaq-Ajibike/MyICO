namespace Domain.Common;

public class BaseEntity
{
    public string Id{ get; set; } = new Guid().ToString().Substring(0, 5);
}
