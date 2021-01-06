using InternshipsBookApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternshipsBookApp.Data.Abstract
{
    public interface IPageDal : IRepositoryBase<Page>
    {
        Page GetById(int pageId);
        List<Page> GetByPageSubject(string subject);
        bool PageExist(int pageNumber, int bookId);
        Page GetPageByNumberAndBookId(int pageNumber, int bookId);
    }
}
