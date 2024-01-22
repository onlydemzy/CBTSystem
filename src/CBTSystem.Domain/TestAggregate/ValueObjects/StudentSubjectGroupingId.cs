using CBTSystem.Domain.Common.Models;

namespace CBTSystem.Domain.TestAggregate.ValueObjects;
public sealed class StudentSubjectGroupingId:AggregateRootId<Guid>
{
    public override Guid Value { get; protected set;}
    private StudentSubjectGroupingId(Guid value)
    {
        Value=value;
    }

    public static StudentSubjectGroupingId CreateUnique()
    {
        return new StudentSubjectGroupingId(Guid.NewGuid());
    }
    public static StudentSubjectGroupingId Create(Guid value)
    {
        return new StudentSubjectGroupingId(value);
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}