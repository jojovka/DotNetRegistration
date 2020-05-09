using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace exxxxxxx.Models
{
    public class Category
    {
        [Required]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Please enter category name")]
        [Display(Name = "Catefory Name")]
        [StringLength(50)]
        [Remote("VerifyName", "Category", HttpMethod = "POST", ErrorMessage = "Name of this category already exists in database.")]
        public string CategoryName { get; set; }
        [Required]
        [StringLength(300)]
        public string Description { get; set; }

        public ICollection<Room> Rooms { get; set; }
    }
}
