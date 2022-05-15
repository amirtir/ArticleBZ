using ArticleBZ.Shared.DTOs;
using ArticleBZ.Shared.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ArticleBZ.Client.Repositories
{
    public interface IUserService
    {
        public Task<Token>  LoginUser(LoginVM loginVM);
        public  Task<User> CreateUser( UserVM userVM);
        public Task<List<User>> GetUsers();
       
    }
}
