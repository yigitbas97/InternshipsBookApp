using InternshipsBookApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternshipsBookApp.Data.Abstract
{
    public interface IUserDal : IRepositoryBase<User>
    {
        User GetByUserId(int userId);
        List<User> GetAllUsersWithBook();
        User GetUserByUsername(string username);
        bool UserExist(string username);
    }
}
