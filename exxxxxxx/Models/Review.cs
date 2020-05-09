using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace exxxxxxx.Models
{
    public class Review: IValidatableObject
    {
        [Required]
        public int ReviewId { get; set; }

        [Required]
        public int UserId { get; set; }
        public User User { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        [Required]
        [StringLength(300)]
        public string Content { get; set; }

        [Required]
        public int RoomId { get; set; }
        public Room Room { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (this.Title.Length > this.Content.Length)
                errors.Add(new ValidationResult("Content must be more that title."));

            return errors;
        }
    }
}
