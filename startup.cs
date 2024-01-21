using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Text;
// using Model;

namespace _20jan.Model{

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("AllowAllOrigins",
                builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
        });
        services.AddDbContext<yourDbContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("DevConnection")));
        services.AddControllers();


        // ... other configurations
    }


    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseHsts(); // <- Ensure this line is present for production
            app.UseHttpsRedirection(); // <- Ensure this line is present for production
        }

        app.UseRouting();

        // Configure other middleware and routes
        // ...
        app.UseCors("AllowAllOrigins");


        // Configure a default route for the root path
        app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

//         app.UseEndpoints(endpoints =>
// {
//     app.UseEndpoints(endpoints =>
//      {
//          endpoints.MapControllerRoute(
//              name: "default",
//              pattern: "{controller=Gebruiker}/{action=Index}/{id?}");
//      });
// });
    }
}

}
