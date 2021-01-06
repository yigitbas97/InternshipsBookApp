using InternshipsBookApp.Data.Abstract;
using InternshipsBookApp.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternshipsBookApp.Data.Concrete
{
    public class BookDal : RepositoryBase<Book, DataContext>, IBookDal
    {
        public List<Book> GetAllBooksWithUserAndPages()
        {
            using(var context = new DataContext())
            {
                return context.Books.Include("User").Include("Pages").ToList();
            }
            
        }

        public Book GetById(int bookId)
        {
            using (var context = new DataContext())
            {
                return context.Books.Include("User").Include("Pages").FirstOrDefault(b => b.Id == bookId);
            }
        }

        public List<Book> GetByUserId(int userId)
        {
            using(var context = new DataContext())
            {
                return context.Books.Where(b => b.UserId == userId).ToList();
            }
        }
    }
}
