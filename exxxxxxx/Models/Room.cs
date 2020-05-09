using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace exxxxxxx.Models
{
    public class Room
    {
        public int RoomId { get; set; }

        [Required(ErrorMessage = "Please enter room quantity")]
        [Display(Name = "Room quantity")]
        [StringLength(50)]
        public int RoomQuantity { get; set; }

        [Required(ErrorMessage = "Please enter category")]
        [Display(Name = "Category")]
        //One-to-Many
        public Category Category { get; set; }

        //One-to-Many
        public ICollection<Review> Reviews { get; set; }

        //One-to-One
        public int BookedUserId { get; set; }
        public User User { get; set; }

        //Many-to-Many
        public IList<MenuRoom> Orders { get; set; }
    }
}
