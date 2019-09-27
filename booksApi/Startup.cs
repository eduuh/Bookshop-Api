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
        public static IConfiguration Configuration { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            //var connectionstring = Configuration["ConnectionStrings:bookDbConnectionString"];

            services.AddDbContext<BookDbContext>(options =>
                options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=BookApiProject;Trusted_Connection=True;"));

            services.AddScoped<ICountryRepository, CountryRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public static void Configure(IApplicationBuilder app, IHostingEnvironment env,BookDbContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //context.SeedDataContext()
            app.Run(async (t) => { await t.Response.WriteAsync("hello world"); });
            app.UseMvc();

        }
    }
}
