using InternshipsBookApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternshipsBookApp.Data.Abstract
{
    public interface IBookDal : IRepositoryBase<Book>
    {
        Book GetById(int bookId);
        List<Book> GetAllBooksWithUserAndPages();
        List<Book> GetByUserId(int userId);
    }
}
