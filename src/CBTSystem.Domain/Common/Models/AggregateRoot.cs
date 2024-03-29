namespace CBTSystem.Domain.Common.Models;
public abstract class AggregateRoot<TId, TIdType>:BaseEntity<TId>
where TId:AggregateRootId<TIdType>
{
    public new AggregateRootId<TIdType> Id{get;protected set;}
    protected AggregateRoot(TId id)
    {
        Id=id;
    }
    #pragma warning disable
    protected AggregateRoot(){}
    #pragma warning restore
}