using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using drink_list_json;
namespace drink_list_json
{
    class Program
    {
        static void Main(string[] args)
        {
            UserInput input = new();
            input.MainMenu();
        }

    }
}
