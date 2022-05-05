using ArticleBZ.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace ArticleBZ.Server
{
    public class Context: DbContext  
    {
        public Context( DbContextOptions<Context> options):base(options)
        {

        }
       
      
        public DbSet<User> users { get; set; }
        public DbSet<Blog> blogs { get; set; }
        public DbSet<Comment> comments { get; set; }
        public DbSet<Role> roles { get; set; }
        public DbSet<Setting> settings { get; set; }
        public DbSet<Status> statuses { get; set; }


    }
}
