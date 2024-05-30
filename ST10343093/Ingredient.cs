using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10343093
{
    public class Ingredient// Ingredient Class
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
        public double calories { get; set; }
        public FoodGroup FoodGroup { get; set; }

    }
}
