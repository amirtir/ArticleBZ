using ArticleBZ.Shared.Models;
using ArticleBZ.Shared.DTOs;
using System.Collections;

namespace ArticleBZ.Server.Repositories
{
    public interface IUserRepository
    {
        public IEnumerable GetAllUsers();
        public bool IsUserExsit(LoginVM login);
        public User Create(UserVM user);
        public User findUserByEmail(string  email);

    }
}
