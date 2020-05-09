using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace exxxxxxx.Models
{
    public class Menu
    {
        [Required]
        public int MenuId { get; set; }

        [Required(ErrorMessage = "Please enter name of dish")]
        [Display(Name = "Name")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter price")]
        [Display(Name = "Price")]
        [Range(100, 100000, ErrorMessage = "Please enter correct range between 100 and 100000")]
        [Price(MinimumPrice = 100.00)]
        public decimal Price { get; set; }

        public IList<MenuRoom> Orders { get; set; }
    }
}
