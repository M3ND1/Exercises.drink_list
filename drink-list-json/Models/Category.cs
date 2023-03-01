using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace drink_list_json.Models
{
    public class Category
    {
        //[JsonProperty("strCategory")]
        public string strCategory { get; set; }
    }
    public class Categories
    {
        public List<Category> drinks { get; set; }
    }
}
