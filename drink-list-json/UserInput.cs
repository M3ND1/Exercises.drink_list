using drink_list_json.Models;
using Newtonsoft.Json;
using System;
using System.Xml.Serialization;

namespace drink_list_json
{
    public class UserInput
    {
        DrinkService drinkService = new DrinkService();
        public void MainMenu()
        {
            while (true)
            {
                drinkService.showCategories();
                getCategories();
                MainMenu();
            }
        }
        internal void getCategories()
        {
            var categories = drinkService.showCategories();
            Console.WriteLine("Choose name of category  \t (to exit type 0)");
            string category = Console.ReadLine();
            if (category == "0") Environment.Exit(0);

            if (!categories.Any(x => x.strCategory == category))
            {
                Console.WriteLine("Category does not exists");
                Console.Write("Press any key to continue... ");
                Console.ReadKey();
                Console.Clear();
                getCategories();
            }
            else
            {
                drinkService.getDrinkByCategory(category);
                getDrinks(category);
            }
        }
        internal void getDrinks(string category)
        {
            Console.WriteLine("Choose drink by Id to see more information \t (to exit type 0)");
            string drink = Console.ReadLine();
            if (drink == "0") Environment.Exit(0);
            var drinkobjects = drinkService.getDrinkByCategory(category);
            if(!drinkobjects.Any(x => x.idDrink == drink)) 
            {
                Console.WriteLine("Provide proper ID!");
                Console.Write("Press any key to continue... ");
                Console.ReadKey();
                Console.Clear();
                getDrinks(category);
            } else
            {
                drinkService.getDrinkInformation(drink);
                Console.Write("Your information about drink is above!");
                Console.Write("\n To continue press any key...");
                Console.ReadKey();
            }
        }
    }
}
