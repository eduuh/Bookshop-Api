using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace booksApi.Models
{
  public class Review
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(200,MinimumLength =10,ErrorMessage ="The HeadLine should range btwn 10-100 characters")]
        public string HeadLine { get; set; }

        [Required]
        [StringLength(2000, MinimumLength = 50, ErrorMessage = "The HeadLine should range btwn 10-100 characters")]
        public string ReviewText { get; set; }

        [Required]
        [Range(1,5,ErrorMessage ="Rating must be a range between 1-5 number;")]
        public int Ratings { get; set; }
        public virtual Reviewer Reviewer { get; set; }
        public virtual Book Book { get; set; }
    }
}
