using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace booksApi.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string HeadLine { get; set; }
        public string ReviewText { get; set; }
        public int Ratings { get; set; }
    }
}
