using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YourHealthBuddy.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SuperCoolTest
{
  [Route("api/[controller]")]
  public class ValuesController : Controller
  {
    [HttpGet]
    public IEnumerable<string> Get()
    {
      return new string[] { "Hello", "Hello", "Hello", "Hello", "Heldlo", "Hello", "Heasdfasdfasdfllo", "Hello", "Hello", "Hello", "Hello", "Hello", "Hello", "Hello", "Wodrld" };
    }

    [HttpGet("[action]")]
    public IEnumerable<string> GetMeals()
    {
      return new string[] { "Breakfast", "Lunch", "Dinner", "Snacks" };
    }

    [HttpGet("[action]")]
    public IEnumerable<Food> GetFoods(string meal)
    {
      List<Food> foods = new List<Food>();

      switch (meal)
      {
        case "Breakfast":
          foods.Add(new Food()
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
          break;
        case "Lunch":
          foods.Add(new Food()
          {
            name = "Chipotle",
            macros = new Macros()
            {
              carb = 90,
              fat = 22,
              protein = 55
            }
          });
          break;
        case "Snacks":
          foods.Add(new Food()
          {
            name = "Salt & Vinegar Chips",
            macros = new Macros()
            {
              carb = 33,
              fat = 9,
              protein = 2
            }
          });
          break;
        case "Dinner":
          foods.Add(new Food()
          {
            name = "Steak",
            macros = new Macros()
            {
              carb = 0,
              fat = 22,
              protein = 30
            }
          });
          break;
      }


      return foods;
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
