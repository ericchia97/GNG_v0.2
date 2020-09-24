using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GNG_v0._2.Models
{
    public interface UserRepository
    {
        User GetUser(int ID);
        IEnumerable<User> GetAllUsers();
        User Register(User users);
        User Update(User users);
        User Delete(int ID);
    }
}
