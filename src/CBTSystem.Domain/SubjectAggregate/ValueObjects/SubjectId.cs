using CBTSystem.Domain.Common.Models;

namespace CBTSystem.Domain.SubjectAggregate.ValueObjects;
public sealed class SubjectId:AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }
    private SubjectId(Guid value)
    {
        Value=value;
    }
    public static SubjectId CreateUnique()
    {
        return new SubjectId(Guid.NewGuid());
    }
    public static SubjectId Create(Guid value)
    {
        return new SubjectId(value);
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}