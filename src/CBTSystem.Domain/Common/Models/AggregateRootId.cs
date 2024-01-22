using System.Dynamic;

namespace CBTSystem.Domain.Common.Models;
public abstract class AggregateRootId<TId>:ValueObject
{
    public abstract TId Value{get; protected set;}
}