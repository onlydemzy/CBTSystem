using CBTSystem.Domain.Common.Models;
using CBTSystem.Domain.Entities.ValueObjects;

namespace CBTSystem.Domain.Entities;
public sealed class Permission:AggregateRoot<PermissionId,Guid>
{
    public string Name{get;private set;}
    private Permission(PermissionId permissionId, string name):base(permissionId)
    {
        Name=name;
    }
    public static Permission Create(string name)=>new (PermissionId.CreateUnique(),name);

}
