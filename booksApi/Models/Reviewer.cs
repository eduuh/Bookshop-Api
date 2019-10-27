using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace booksApi.Models
{
    public class Reviewer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100,ErrorMessage ="The FirstName should not exceed 100 characters")]
        public string Firstname { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "The LastName should not exceed 200 characters")]
        public string Lastname { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
