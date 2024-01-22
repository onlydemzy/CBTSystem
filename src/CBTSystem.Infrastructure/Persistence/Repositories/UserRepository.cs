using CBTSystem.Application.Common.interfaces.Persistence;
using CBTSystem.Entities;

namespace CBTSystem.Infrastructure.Persistence.Repositories;
public class UserRepository:IUserRepository
{
    private static readonly List<User> users = [];

    public void Add(User user)
    =>users.Add(user);
}