using System.Security.Claims;

namespace CBTSystem.Infrastructure.Interfaces;
public interface IUserPermissionService
{
    /// <summary>
        /// Returns a new identity containing the user permissions as Claims
        /// </summary>
        /// <param name="sub">The user external id (sub claim)</param>
        /// <param name="cancellationToken"></param>
        ValueTask<ClaimsIdentity?> GetUserPermissionsIdentity(string sub, CancellationToken cancellationToken);
}