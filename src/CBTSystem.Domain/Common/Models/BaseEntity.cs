
namespace CBTSystem.Domain.Common.Models;
public abstract class BaseEntity<TId> : IEquatable<BaseEntity<TId>>, IHasDomainEvents where TId:ValueObject
{
   private readonly List<IDomainEvent> _domainEvents=[];
    public TId Id{get; private set;}
    public IReadOnlyList<IDomainEvent> DomainEvents=>_domainEvents.AsReadOnly();
    protected BaseEntity(TId id)
    {
        Id=id;
    }
    public void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
    #pragma warning disable
    protected BaseEntity(){}
    #pragma warning restore
    public override bool Equals(object? obj)
    {
        return obj is BaseEntity<TId> entity && Id.Equals(entity.Id);
    }

    public bool Equals(BaseEntity<TId>? other)
    {
       return other is BaseEntity<TId> entity && Id.Equals(entity.Id);
    }

    public static bool operator==(BaseEntity<TId> left, BaseEntity<TId> right)
    {
        return Equals(left,right);
    }
    public static bool operator!=(BaseEntity<TId> left, BaseEntity<TId> right)
    {
        return !Equals(left,right);
    }

    public override int GetHashCode()
    {
        return (GetType()
        .ToString() +Id).GetHashCode();
    }
}