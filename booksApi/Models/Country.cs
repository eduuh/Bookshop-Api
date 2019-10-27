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
        [StringLength(50,ErrorMessage ="The Contry Name should be less than 50 chars")]
        public string Name { get; set; }

        public virtual ICollection<Author> Authors { get; set; }

    }
}
