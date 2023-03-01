using drink_list_json.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace drink_list_json
{
    public class DrinkService
    {
        public List<Category> showCategories()
        {
            string url = "http://www.thecocktaildb.com/api/json/v1/1/list.php?c=list";
            using (HttpClient client = new HttpClient())
            {
                List<Category> categ = new();
                HttpResponseMessage response = client.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;
                    var serialize = JsonConvert.DeserializeObject<Categories>(json);

                    categ = serialize.drinks;
                    DisplayTable.display(categ,"Categories");
                    return categ;
                }
                return categ;
            }
        }
        public List<Drink> getDrinkByCategory(string category)
        {
            Console.Clear();
            string url = $"http://www.thecocktaildb.com/api/json/v1/1/filter.php?c="+category;
            List<Drink> drink = new();
            using (HttpClient client = new HttpClient()) 
            {
                HttpResponseMessage response = client.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result; 
                    var serialize = JsonConvert.DeserializeObject<Drinks>(json); 

                    drink = serialize.drinks;
                    DisplayTable.display(drink, "Drink List");
                    return drink;
                } 
                return drink;
            }
        }
        public void getDrinkInformation(string drink)
        {
            Console.Clear();
            string url = "http://www.thecocktaildb.com/api/json/v1/1/lookup.php?i="+drink;
            using(HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(url).Result;
                if(response.IsSuccessStatusCode)
                {
                    var json = response.Content.ReadAsStringAsync().Result;
                    var seralize = JsonConvert.DeserializeObject<Root>(json);

                    List<DrinksInfo> drinkInfo = new();
                    drinkInfo = seralize.drinks;
                    DrinksInfo info = drinkInfo[0];
                    List<object> propList = new();
                    string formattedName = "";
                    foreach (PropertyInfo prop in info.GetType().GetProperties())
                    {

                        if (prop.Name.Contains("str")) formattedName = prop.Name.Substring(3);
                        if (!string.IsNullOrEmpty(prop.GetValue(info)?.ToString()))
                        {
                            propList.Add(new
                            {
                                Key = formattedName,
                                Value = prop.GetValue(info)
                            });
                        }
                    }
                    DisplayTable.display(propList, info.strDrink);

                }
            }
        }
    }
}
