using InternshipsBookApp.Data.Abstract;
using InternshipsBookApp.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternshipsBookApp.Data.Concrete
{
    public class PageDal : RepositoryBase<Page, DataContext>, IPageDal
    {
        public Page GetById(int pageId)
        {
            using(var context = new DataContext())
            {
                return context.Pages.Include("Book").FirstOrDefault(p => p.Id == pageId);
            }
        }

        public List<Page> GetByPageSubject(string subject)
        {
            using (var context = new DataContext())
            {
                return context.Pages.Include("Book").Where(p => p.Subject.ToLower().Contains(subject.ToLower())).ToList();
            }
        }

        public Page GetPageByNumberAndBookId(int pageNumber, int bookId)
        {
            using(var context = new DataContext())
            {
                return context.Pages.FirstOrDefault(p => p.Number == pageNumber && p.BookId == bookId);
            }
        }

        public bool PageExist(int pageNumber, int bookId)
        {
            using(var context = new DataContext())
            {
                var book = context.Books.Include("Pages").FirstOrDefault(b => b.Id == bookId);
                return book.Pages.Any(p => p.Number == pageNumber);
            }
        }
    }
}
