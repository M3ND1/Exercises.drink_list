namespace drink_list_json
{
    public class UserInput
    {
        public void MainMenu()
        {
            bool closeApp = false;
            while (!closeApp)
            {
                Console.WriteLine("Choose number from 0 to 3");
                Console.WriteLine("0 - break");
                Console.WriteLine("1 - Categories");
                Console.WriteLine("2 - TODO(not working)");
                Console.WriteLine("3 - TODO(not working)");
                int n = GetNumber();
                Console.Clear();
                switch (n)
                {
                    case 0:
                        closeApp = true;
                        break;
                    case 1:
                        DrinkService.showCategories();
                        Console.WriteLine("\nChoose category and see drinks!");
                        string categ = Console.ReadLine();
                        DrinkService.getCategories(categ);
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    default:
                        Console.WriteLine("Provide number as shown below.\n");
                        break;
                };
            }
        }
        static int GetNumber()
        {
            int sol = 99;
            bool flag = false;
            while (flag == false)
            {
                try
                {
                    sol = Convert.ToInt32(Console.ReadLine());
                    flag = true;
                }
                catch (FormatException)
                {
                    Console.Clear();
                    Console.WriteLine("You did not provide proper number.\n");
                }
            }
            return sol;
        }
    }
}
