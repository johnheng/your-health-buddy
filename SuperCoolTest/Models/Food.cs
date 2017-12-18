using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YourHealthBuddy.Models
{
  public class Food
  {
    public string id { get; set; }
    public string name { get; set; }
    public Macros macros { get; set; }
    public Micros micros { get; set; }
    public int servingSize { get; set; }
    public string servingMeasurement { get; set; }
  }

  public class Macros
  {
    public string id { get; set; }
    public int carb { get; set; }
    public int fat { get; set; }
    public int protein { get; set; }
  }

  public class Micros
  {
    public string id { get; set; }
    public int sodium { get; set; }
    public int fiber { get; set; }
    public int vitaminC { get; set; }
    public int sugar { get; set; }
    public int cholesterol { get; set; }
    public int iron { get; set; }
  }
}
