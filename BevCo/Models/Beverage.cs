using System.Collections.Generic;

namespace BevCo.Models
{
  public class Beverage
  {
    public Beverage()
    {
      this.JoinEntities = new HashSet<CategoryBeverage>();
    }

    public int BeverageId { get; set; }
    public string BeverageName { get; set; }
    public string Description { get; set; }
    public int CalorieCount {get; set; }
    public string CountryOfOrigin {get; set; }
    public int Cost {get; set; }
    public int BottleCount {get; set; }
    public int IndividualBottleSize {get; set;}
    public int StockCount {get; set;}
    public virtual ICollection<CategoryBeverage> JoinEntities { get;}
  }
}

