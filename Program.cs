using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;

namespace JsonExample
{
    class Program
    {
        // Base class
        public class User
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public string City { get; set; }
        }

        // AdminUser inherits from User
        public class AdminUser : User
        {
            public List<string> Permissions { get; set; }
        }

        // RegularUser inherits from User
        public class RegularUser : User
        {
            public string SubscriptionLevel { get; set; }
        }

        static void Main(string[] args)
        {
            string filePath = "user.json";

            if (File.Exists(filePath))
            {
                string jsonResponse = File.ReadAllText(filePath);

                // Parse JSON array manually for dynamic deserialization
                JArray jsonArray = JArray.Parse(jsonResponse);
                List<User> users = new List<User>();

                foreach (var item in jsonArray)
                {
                    string userType = item.Value<string>("user_type");

                    switch (userType)
                    {
                        case "admin":
                            AdminUser admin = item.ToObject<AdminUser>();
                            users.Add(admin);
                            break;

                        case "regular":
                            RegularUser regular = item.ToObject<RegularUser>();
                            users.Add(regular);
                            break;
                    }
                }

                // Output users
                foreach (var user in users)
                {
                    Console.WriteLine("----------------------");
                    Console.WriteLine($"Name: {user.Name}");
                    Console.WriteLine($"Age: {user.Age}");
                    Console.WriteLine($"City: {user.City}");

                    if (user is AdminUser admin)
                    {
                        Console.WriteLine("Type: Admin");
                        Console.WriteLine("Permissions: " + string.Join(", ", admin.Permissions));
                    }
                    else if (user is RegularUser regular)
                    {
                        Console.WriteLine("Type: Regular");
                        Console.WriteLine("Subscription Level: " + regular.SubscriptionLevel);
                    }
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
