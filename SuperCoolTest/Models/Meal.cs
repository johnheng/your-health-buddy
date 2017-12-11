using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YourHealthBuddy.Models
{
  public class Meal
  {
    public string name { get; set; }
    public List<Food> foods { get; set; }
  }
}
