using CBTSystem.Domain.Common.Models;

namespace CBTSystem.Domain.Entities.ValueObjects;
public sealed class PermissionId:AggregateRootId<Guid>
{
    public override Guid Value{get; protected set;}
    private PermissionId(Guid value)
    {
        Value=value;
    }
    public static PermissionId CreateUnique()
    =>new(Guid.NewGuid());
  
    public static PermissionId Create(Guid value)
    =>new (value);

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

     
}