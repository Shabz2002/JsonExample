using Newtonsoft.Json;
using System;
using System.IO;

namespace JsonExample
{
    class Program
    {
        public class User
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public string City { get; set; }
        }

        static void Main(string[] args)
        {
            string filePath = "user.json";

            if (File.Exists(filePath))
            {
                string jsonResponse = File.ReadAllText(filePath);
                User user = JsonConvert.DeserializeObject<User>(jsonResponse);

                Console.WriteLine($"Name: {user.Name}");
                Console.WriteLine($"Age: {user.Age}");
                Console.WriteLine($"City: {user.City}");
            }
            else
            {
                Console.WriteLine("user.json not found!");
            }
        }
    }
}
