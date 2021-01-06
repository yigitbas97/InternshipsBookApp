using InternshipsBookApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternshipsBookApp.AuthRepositoryFolder.Abstract
{
    public interface IAuthRepository
    {
        User Login(string username, string password);
        bool VerifyPasswordHash(string password, byte[] userPasswordHash, byte[] userPasswordSalt);
        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
        User Register(User user, string password);
    }
}
