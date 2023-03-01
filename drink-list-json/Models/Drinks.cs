using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace drink_list_json.Models
{
    public class Drink
    { 
        public string idDrink { get; set; }
        public string strDrink { get; set; }
        public string strDrinkThumb { get; set; }
    }
    public class Drinks
    {
        public List<Drink> drinks { get; set; }
    }
}
