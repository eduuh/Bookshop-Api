using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace booksApi.Services
{
    public class BookDbContextFactory : IDesignTimeDbContextFactory<BookDbContext>
    {
       
       
        public BookDbContext CreateDbContext(string[] args)
        {
            var optionbuilder = new DbContextOptionsBuilder<BookDbContext>();
            var connectionstring = "Server=(localdb)\\mssqllocaldb;Database=BookApiProject;Trusted_Connection=True;";

            optionbuilder.UseSqlServer(connectionstring);
            return new BookDbContext(optionbuilder.Options);
        }
    }
}
