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
            UserList = new List<User>();
        }


        public User GetUser(int ID)
        {
            return UserList.FirstOrDefault(e => e.Id == ID);
        }

        public User Register(User users)
        {
            if (users == null)
            {
                users.Id = 1;
            }
            else
            {
                users.Id = UserList.Max(e => e.Id) + 1;
            }
            UserList.Add(users);
            return users;
        }

        public User Delete(int ID)
        {
            User deletedUser = UserList.FirstOrDefault(e => e.Id == ID);
            if (deletedUser != null)
            {
                UserList.Remove(deletedUser);
            }
            return deletedUser;
        }


        public User Update(User users)
        {
            User UpdatedUser = UserList.FirstOrDefault(e => e.Id == users.Id);
            if (UpdatedUser != null)
            {
                UpdatedUser.Name = users.Name;
                UpdatedUser.Email = users.Email;
                UpdatedUser.Password = users.Password;
            }
            return UpdatedUser;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return UserList;
        }
    }
}
