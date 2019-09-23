using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace booksApi.Services
{
    public class BookDbContextFactory : IDesignTimeDbContextFactory<BookDbContext>
    {

        private static IConfiguration configuration { get; set; }
        
       
        public BookDbContext CreateDbContext(string[] args)
        {
            //var  connectionstring = configuration.GetConnectionString("bookDbConnectionString");       
            var optionbuilder = new DbContextOptionsBuilder<BookDbContext>();
            var connectionstring = "Server=(localdb)\\mssqllocaldb;Database=BookApiProject;Trusted_Connection=True;"; 
            optionbuilder.UseSqlServer(connectionstring);
            return new BookDbContext(optionbuilder.Options);
        }
    }
}
