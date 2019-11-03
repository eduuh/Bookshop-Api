using System;
using System.Collections.Generic;
using booksApi.Models;
using booksApi.Services;

namespace booksApi
{
  public static class DbSeedingClass
    {
        //Extension method
        public static void SeedDataContext(this BookDbContext context)
        {
            var booksAuthors = new List<BookAuthor>()
            {
                new BookAuthor()
                {
                    Book = new Book()
                    {
                        isbn = "123",
                        Title = "The Call Of The Wild",
                        DatePublished = new DateTime(1903, 1, 1),
                        BookCategories = new List<BookCategory>()
                        {
                            new BookCategory {Category = new Category() {Name = "Action"}}
                        },
                        Reviews = new List<Review>()
                        {
                            new Review
                            {
                                HeadLine = "Awesome Book",
                                ReviewText = "Reviewing Call of the Wild and it is awesome beyond words", Ratings = 5,
                                Reviewer = new Reviewer() {Firstname = "John", Lastname = "Smith"}
                            },
                            new Review
                            {
                                HeadLine = "Terrible Book",
                                ReviewText = "Reviewing Call of the Wild and it is terrrible book", Ratings = 1,
                                Reviewer = new Reviewer() {Firstname = "Peter", Lastname = "Griffin"}
                            },
                            new Review
                            {
                                HeadLine = "Decent Book", ReviewText = "Not a bad read, I kind of liked it",
                                Ratings = 3,
                                Reviewer = new Reviewer() {Firstname = "Paul", Lastname = "Griffin"}
                            }
                        }
                    },
                    Author = new Author()
                    {
                        FirstName = "Jack",
                        Lastname = "London",
                        Country = new Country()
                        {
                            Name = "USA"
                        }
                    }
                },
                new BookAuthor()
                {
                    Book = new Book()
                    {
                        isbn = "1234",
                        Title = "Winnetou",
                        DatePublished = new DateTime(1878, 10, 1),
                        BookCategories = new List<BookCategory>()
                        {
                            new BookCategory {Category = new Category() {Name = "Western"}}
                        },
                        Reviews = new List<Review>()
                        {
                            new Review
                            {
                                HeadLine = "Awesome Western Book",
                                ReviewText = "Reviewing Winnetou and it is awesome book", Ratings = 4,
                                Reviewer = new Reviewer() {Firstname = "Frank", Lastname = "Gnocci"}
                            }
                        }
                    },
                    Author = new Author()
                    {
                        FirstName = "Karl",
                        Lastname = "May",
                        Country = new Country()
                        {
                            Name = "Germany"
                        }
                    }
                },
                new BookAuthor()
                {
                    Book = new Book()
                    {
                        isbn = "12345",
                        Title = "Pavols Best Book",
                        DatePublished = new DateTime(2019, 2, 2),
                        BookCategories = new List<BookCategory>()
                        {
                            new BookCategory {Category = new Category() {Name = "Educational"}},
                            new BookCategory {Category = new Category() {Name = "Computer Programming"}}
                        },
                        Reviews = new List<Review>()
                        {
                            new Review
                            {
                                HeadLine = "Awesome Programming Book",
                                ReviewText = "Reviewing Pavols Best Book and it is awesome beyond words", Ratings = 5,
                                Reviewer = new Reviewer() {Firstname = "Pavol2", Lastname = "Almasi2"}
                            }
                        }
                    },
                    Author = new Author()
                    {
                        FirstName = "Pavol",
                        Lastname = "Almasi",
                        Country = new Country()
                        {
                            Name = "Slovakia"
                        }
                    }
                },
                new BookAuthor()
                {
                    Book = new Book()
                    {
                        isbn = "123456",
                        Title = "Three Musketeers",
                        DatePublished = new DateTime(2019, 2, 2),
                        BookCategories = new List<BookCategory>()
                        {
                            new BookCategory {Category = new Category() {Name = "Action"}},
                            new BookCategory {Category = new Category() {Name = "History"}}
                        }
                    },
                    Author = new Author()
                    {
                        FirstName = "Alexander",
                        Lastname = "Dumas",
                        Country = new Country()
                        {
                            Name = "France"
                        }
                    }
                },
                new BookAuthor()
                {
                    Book = new Book()
                    {
                        isbn = "1234567",
                        Title = "Big Romantic Book",
                        DatePublished = new DateTime(1879, 3, 2),
                        BookCategories = new List<BookCategory>()
                        {
                            new BookCategory {Category = new Category() {Name = "Romance"}}
                        },
                        Reviews = new List<Review>()
                        {
                            new Review
                            {
                                HeadLine = "Good Romantic Book", ReviewText = "This book made me cry a few times",
                                Ratings = 5,
                                Reviewer = new Reviewer() {Firstname = "Allison", Lastname = "Kutz"}
                            },
                            new Review
                            {
                                HeadLine = "Horrible Romantic Book",
                                ReviewText = "My wife made me read it and I hated it", Ratings = 1,
                                Reviewer = new Reviewer() {Firstname = "Kyle", Lastname = "Kutz"}
                            }
                        }
                    },
                    Author = new Author()
                    {
                        FirstName = "Anita",
                        Lastname = "Powers",
                        Country = new Country()
                        {
                            Name = "Canada"
                        }
                    }
                }
            };

            context.BookAuthors.AddRange(booksAuthors);
            context.SaveChanges();
        }
    }
}
