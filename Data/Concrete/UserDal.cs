using InternshipsBookApp.Data.Abstract;
using InternshipsBookApp.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternshipsBookApp.Data.Concrete
{
    public class UserDal : RepositoryBase<User, DataContext>, IUserDal
    {
        public List<User> GetAllUsersWithBook()
        {
            using(var context = new DataContext())
            {
                return context.Users.Include("Books").ToList();
            }
        }

        public User GetByUserId(int userId)
        {
            using (var context = new DataContext())
            {
                return context.Users.Include("Books").FirstOrDefault(u => u.Id == userId);
            }
        }

        public User GetUserByUsername(string username)
        {
            using (var context = new DataContext())
            {
                return context.Users.FirstOrDefault(u => u.Username == username);
            }
        }

        public bool UserExist(string username)
        {
            using(var context = new DataContext())
            {
                return context.Users.Any(u => u.Username == username);
            }
        }
    }
}
