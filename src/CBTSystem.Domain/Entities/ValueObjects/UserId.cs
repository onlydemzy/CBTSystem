using CBTSystem.Domain.Common.Models;

namespace CBTSystem.Domain.Entities.ValueObjects;
public sealed class UserId:AggregateRootId<string>
{
    public override string Value{get; protected set;}
    private UserId(string value)
    {
        Value=value;
    }
    private static UserId CreateUnique()
    =>new(Guid.NewGuid().ToString());
  
    public static UserId Create(string value)
    =>new (value);

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

     
}