

using ArticleBZ.Shared.DTOs;
using ArticleBZ.Shared.Models;
using System.Collections;
using System.Linq;

namespace ArticleBZ.Server.Repositories
{
    public class UserRepository: IUserRepository
    { 

      private Context _context;
        public UserRepository( Context context)
        {
        _context = context;
        }

        public User Create(UserVM user)
        {
            User _user = new User()
            {
                Name = user.Name,
                LastName = user.LastName,
                Email = user.Email,
                Bio = user.Bio,
                Password = user.Password,
                Job = user.Job,
                RoleId =1,
                StatusId=1,
                Blogs=null,
                
            


            };
            _context.users.Add(_user);
            _context.SaveChanges();
            return _user;
        }

        public User findUserByEmail(string email)
        {
          return  _context.users.FirstOrDefault(u=>u.Email==email);
        }

        public IEnumerable GetAllUsers()
        {
           return _context.users.ToList();
        }

        public bool IsUserExsit(Shared.DTOs.LoginVM login)
        {

         var result=  _context.users.Any(u => u.Email == login.Email && u.Password == login.Password);
            return result;
        }
    }
}
