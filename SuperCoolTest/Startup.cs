using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Swagger;
using YourHealthBuddy.Contexts;
using System.IO;
using YourHealthBuddy.Models;

namespace SuperCoolTest
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvc();

      services.AddDbContext<DatabaseContext>(options => options.UseInMemoryDatabase("MyDatabase"));

      services.AddCors(options => options.AddPolicy("Cors", builder =>
      {
        builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
      }));

      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      app.Use(async (context, next) =>
      {
        await next();
        if (context.Response.StatusCode == 404 &&
           !Path.HasExtension(context.Request.Path.Value) &&
           !context.Request.Path.Value.StartsWith("/api/"))
        {
          context.Request.Path = "/index.html";
          await next();
        }
      });

      // Enable middleware to serve generated Swagger as a JSON endpoint.
      app.UseSwagger();

      // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
      app.UseSwaggerUI(c =>
      {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
      });

      app.UseMvcWithDefaultRoute();
      app.UseDefaultFiles();
      app.UseStaticFiles();

      using (var serviceScope = app.ApplicationServices.CreateScope())
      {
        var context = serviceScope.ServiceProvider.GetService<DatabaseContext>();
        SeedFoods(context);
        SeedMeals(context);
      }
    }

    public void SeedFoods(DatabaseContext db)
    {
      db.Foods.Attach(new Food()
      {
        name = "Blueberry Waffles",
        macros = new Macros()
        {
          carb = 30,
          fat = 15,
          protein = 5
        },
        micros = new Micros()
        {
          sodium = 3000,
          sugar = 30
        },
        servingSize = 1,
        servingMeasurement = "waffle"
      });

      db.Foods.Attach(new Food()
      {
        name = "Chipotle",
        macros = new Macros()
        {
          carb = 90,
          fat = 22,
          protein = 55
        }
      });

      db.Foods.Attach(new Food()
      {
        name = "Salt & Vinegar Chips",
        macros = new Macros()
        {
          carb = 33,
          fat = 9,
          protein = 2
        }
      });

      db.Foods.Attach(new Food()
      {
        name = "Steak",
        macros = new Macros()
        {
          carb = 0,
          fat = 22,
          protein = 30
        }
      });

      db.SaveChanges();
    }

    public void SeedMeals(DatabaseContext db)
    {
      var myMeal = new Meal()
      {
        name = "Dinner",
        foods = db.Foods.ToList()
      };

      db.Meals.Attach(new Meal()
      {
        name = "Lunch",
        foods = new List<Food>()
        {
          new Food()
          {
            name = "Blueberry Waffles",
            macros = new Macros()
            {
              carb = 30,
              fat = 15,
              protein = 5
            },
            micros = new Micros()
            {
              sodium = 3000,
              sugar = 30
            },
            servingSize = 1,
            servingMeasurement = "waffle"
          }
        }
      });

      db.SaveChanges();
    }
  }
}
