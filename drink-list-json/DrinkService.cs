using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace drink_list_json
{
    public class DrinkService
    {
        public static void showCategories()
        {
            string url = "http://www.thecocktaildb.com/api/json/v1/1/list.php?c=list";
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;
                    Categories categories = JsonConvert.DeserializeObject<Categories>(json);
                    foreach (Category category in categories.drinks)
                    {
                        Console.WriteLine(category.strCategory);
                    }
                }
            }
        }
        public static void getCategories(string category)
        {
            string url = $"http://www.thecocktaildb.com/api/json/v1/1/filter.php?c="+category;//{HttpUtility.UrlEncode(category)}"; //or RestRequest
            using (HttpClient client = new HttpClient()) 
            {
                HttpResponseMessage response = client.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;
                    Drinks list_drink = JsonConvert.DeserializeObject<Drinks>(json);
                    foreach (Drink drink in list_drink.drinks)
                    {
                        Console.WriteLine("{0}  {1}", drink.idDrink, drink.strDrink);
                    }
                }
            }
        }
        public static void getDrinkInfo(string drink)
        {

        }
    }
}
