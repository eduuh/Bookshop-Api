using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace booksApi.Models
{
  public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50,ErrorMessage ="Category name should be less than 50 chars")]
        public string Name { get; set; }
        public ICollection<BookCategory> BookCategories { get; set; }
    }
}
