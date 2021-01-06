using InternshipsBookApp.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InternshipsBookApp.Models
{
    public class BookViewModel
    {
        public List<Book> Books { get; set; }
    }
}
