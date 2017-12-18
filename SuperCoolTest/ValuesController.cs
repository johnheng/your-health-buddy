using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YourHealthBuddy.Models;
using YourHealthBuddy.Contexts;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SuperCoolTest
{
  [Route("api/[controller]")]
  public class ValuesController : Controller
  {
    readonly DatabaseContext context;
    public ValuesController(DatabaseContext context)
    {
      this.context = context;
    }

    [HttpGet]
    public List<Food> Get()
    {
      return context.Foods.ToList();
    }

    [HttpGet("[action]")]
    public IEnumerable<string> GetMeals()
    {
      return context.Meals.Select(x => x.name).ToList();
    }

    /// <summary>
    /// Gets the foods eaten for a specific meal.
    /// </summary>
    /// <param name="meal"></param>
    /// <returns></returns>
    [HttpGet("[action]")]
    public IEnumerable<Food> GetFoodsForMeal(string meal)
    {
      return context.Meals.FirstOrDefault(x => x.name == meal).foods.ToList();
    }

    [HttpGet("[action]")]
    public List<Meal> GetDiary()
    {
      var diary = new List<Meal>();

      diary.Add(new Meal()
      {
        name = "Breakfast",
        foods = new List<Food>() { new Food()
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

      diary.Add(new Meal()
      {
        name = "Lunch",
        foods = new List<Food>() { new Food()
          {
            name = "Chipotle",
            macros = new Macros()
            {
              carb = 90,
              fat = 22,
              protein = 55
            }
          }
        }
      });

      diary.Add(new Meal()
      {
        name = "Dinner",
        foods = new List<Food>() {
          new Food()
          {
            name = "Steak",
            macros = new Macros()
            {
              carb = 0,
              fat = 22,
              protein = 30
            }
          }
        }
      });

      diary.Add(new Meal()
      {
        name = "Snacks",
        foods = new List<Food>() { new Food()
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

      return diary;
    }
  }
}
