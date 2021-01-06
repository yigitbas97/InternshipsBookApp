using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InternshipsBookApp.Models
{
    public class BookAddViewModel
    {
        [Required]
        [Display(Name = "Staj Yeri")]
        public string InternshipPlace { get; set; }
        [Required]
        [Display(Name = "Departman")]
        public string Department { get; set; }
        [Required]
        [Display(Name = "Teslim Tarihi")]
        public DateTime DeliveryDate { get; set; }
    }
}
