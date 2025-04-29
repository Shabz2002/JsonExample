using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace JsonExample
{
    class Program
    {
        // Define a class to match the JSON structure
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
                // Read JSON content from the file
                string jsonResponse = File.ReadAllText(filePath);

                // Deserialize the JSON into a list of User objects
                List<User> users = JsonConvert.DeserializeObject<List<User>>(jsonResponse);

                Console.WriteLine("User List:");
                foreach (var user in users)
                {
                    Console.WriteLine("----------------------");
                    Console.WriteLine($"Name: {user.Name}");
                    Console.WriteLine($"Age: {user.Age}");
                    Console.WriteLine($"City: {user.City}");
                }
            }
            else
            {
                Console.WriteLine("user.json not found!");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
