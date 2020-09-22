using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GNG_v0._2.Models
{
    public class MockUserRepository : UserRepository
    {
        private List<User> UserList;

        public MockUserRepository()
        {

        }
        public User GetUser(int ID)
        {
            throw new NotImplementedException();
        }
    }
}
