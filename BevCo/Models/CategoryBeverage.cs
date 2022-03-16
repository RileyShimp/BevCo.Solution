namespace BevCo.Models
{
  public class CategoryBeverage
    {       
        public int CategoryBeverageId { get; set; }
        public int BeverageId { get; set; }
        public int CategoryId { get; set; }
        public virtual Beverage Beverage { get; set; }
        public virtual Category Category { get; set; }
    }
}