using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace booksApi.Models
{
    public class Author
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage ="Firstname Cannot be more than 100 characters.")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100,ErrorMessage ="Lastname Cannot be more than 100 characters")]
        public string Lastname { get; set; }
        public virtual Reviewer Country { get; set; }
        public virtual ICollection<BookAuthor> BookAuthors { get; set; }
    }
}
