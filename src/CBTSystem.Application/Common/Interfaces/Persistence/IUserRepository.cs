using CBTSystem.Entities;

namespace CBTSystem.Application.Common.interfaces.Persistence;
    public interface IUserRepository
    {
        public void Add(User user);
    }