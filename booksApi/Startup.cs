using booksApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

namespace booksApi
{
  public class Startup
  {
    public static IConfiguration configuration { get; set; }
    public Startup(IConfiguration configurations)
    {
      configuration = configurations;
    }
    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public static void ConfigureServices(IServiceCollection services)
    {
      services.AddMvc();

      //var connectionstring = Configuration["ConnectionStrings:bookDbConnectionString"];
      var DefaultConnection = "Server=(localdb)\\MSSQLLocalDB;Database=booksdb;Trusted_Connection=True;MultipleActiveResultSets=true;";
      services.AddDbContext<BookDbContext>(options =>
                options.UseSqlServer(DefaultConnection));

      services.AddScoped<ICountry, CountryRepository>();
      services.AddScoped<ICategory, CategoriesRepository>();
      services.AddScoped<IReviewer, ReviewerRepository>();
      services.AddScoped<IAuthor, AuthorRepository>();
      services.AddScoped<IBook, BookRepository>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public static void Configure(IApplicationBuilder app, IHostingEnvironment env, BookDbContext context)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

     //context.SeedDataContext();
      app.UseMvcWithDefaultRoute();
      app.UseMvc();

    }
  }
}
