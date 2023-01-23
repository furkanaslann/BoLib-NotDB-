using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bolib.com.webui.Models
{
    public class Book
    {
        public int BookId { get; set; }

        [Required]
        [StringLength(65, MinimumLength = 3, ErrorMessage = "Please enter name between 3-65!!!")]
        public string BookName { get; set; }

        //[Required]
        //[StringLength(5000, MinimumLength =3, ErrorMessage = "Pay attention to the number of characters!!!")]
        public string Description { get; set; }

        [Required(ErrorMessage = "You can enter price!")]
        [Range(1, 100000)]
        public double? Price { get; set; }

        public string ImageUrl { get; set; }
        public bool IsApproved { get; set; }
        public int CategoryId { get; set; }
    }
}
