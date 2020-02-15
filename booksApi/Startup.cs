using booksApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;

namespace booksApi
{
    public class Startup
    {
        public static IConfiguration Configuration { get; set; }
        private static readonly string _connStr = @"
                                            Server=127.0.0.1,1401;
                                            Database=books;
                                            User Id=sa;
                                            Password=YourSTRONG!Passw0rd
                                            ";

        public Startup(IConfiguration configurations)
        {
            Configuration = configurations;
        }
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //var connectionstring = Configuration["ConnectionStrings:bookDbConnectionString"];

            services.AddDbContext<BookDbContext>(options =>
                      options.UseSqlServer(_connStr));

            services.AddScoped<ICountry, CountryRepository>();
            services.AddScoped<ICategory, CategoriesRepository>();
            services.AddScoped<IReviewer, ReviewerRepository>();
            services.AddScoped<IAuthor, AuthorRepository>();
            services.AddScoped<IBook, BookRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endPoints =>
            {
                endPoints.MapControllers();
            });

        }
    }
}
