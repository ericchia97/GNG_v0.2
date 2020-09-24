using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GNG_v0._2.Models
{
    public class SQLUserRepository : UserRepository
    {
        private readonly AppDbContext context;
        public SQLUserRepository(AppDbContext context)
        {
            this.context = context;
        }
        public User Delete(int ID)
        {
            User delete = context.Users.Find();
            if(delete != null)
            {
                context.Users.Remove(delete);
                context.SaveChanges();
            }
            return delete;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return context.Users;
        }

        public User GetUser(int ID)
        {
            return context.Users.Find(ID);
        }

        public User Register(User users)
        {
            context.Users.Add(users);
            context.SaveChanges();
            return users;
        }

        public User Update(User users)
        {
            var user = context.Users.Attach(users);
            user.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return users;
        }
    }
}
