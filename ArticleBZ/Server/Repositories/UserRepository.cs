

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

       public bool IsUserExsit(Shared.DTOs.LoginVM login)
        {

         var result=  _context.users.Any(u => u.Name == login.UserName && u.Password == login.Password);
            return result;
        }
    }
}
