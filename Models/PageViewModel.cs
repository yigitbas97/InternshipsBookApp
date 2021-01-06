using InternshipsBookApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternshipsBookApp.Models
{
    public class PageViewModel
    {
        public int BookId { get; set; }
        public List<Page> Pages { get; set; }
    }
}
