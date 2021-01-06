using InternshipsBookApp.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InternshipsBookApp.Models
{
    public class PageExamineViewModel
    {
        [Required]
        [Display(Name = "Sayfa Numarası")]
        public int Number { get; set; }
        [Required]
        [Display(Name = "Sayfa Konusu")]
        public string Subject { get; set; }
        [Required]
        [Display(Name = "Sayfa İçeriği")]
        public string PageContent { get; set; }

        [Required]
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
