using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InternshipsBookApp.Entities
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string InternshipPlace { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        public DateTime DeliveryDate { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        public ICollection<Page> Pages { get; set; }
    }
}
