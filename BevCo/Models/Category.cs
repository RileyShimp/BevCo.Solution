using System.Collections.Generic;

namespace BevCo.Models
{
    public class Category
    {
        public Category()
        {
            this.JoinEntities = new HashSet<CategoryBeverage>();
        }

        public int CategoryId { get; set; }
        public string Name { get; set; }
        public bool IsAlcoholic { get; set; }
        public virtual ICollection<CategoryBeverage> JoinEntities { get; set; }
    }
}