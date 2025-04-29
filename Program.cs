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

        public class AdminUser : User
        {
            public List<string> Permissions { get; set; }
        }

        public class RegularUser : User
        {
            public string SubscriptionLevel { get; set; }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Reading from user.json...");
            ReadAndDisplayUsers("user.json");

            Console.WriteLine("\nReading from user_types.json...");
            ReadAndDisplayUsers("user_types.json");

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        static void ReadAndDisplayUsers(string fileName)
        {
            if (File.Exists(fileName))
            {
                string jsonResponse = File.ReadAllText(fileName);
                JArray jsonArray = JArray.Parse(jsonResponse);
                List<User> users = new List<User>();

                foreach (var item in jsonArray)
                {
                    string userType = item.Value<string>("user_type");

                    switch (userType)
                    {
                        case "admin":
                            users.Add(item.ToObject<AdminUser>());
                            break;
                        case "regular":
                            users.Add(item.ToObject<RegularUser>());
                            break;
                        default:
                            users.Add(item.ToObject<User>()); // fallback
                            break;
                    }
                }

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
                Console.WriteLine($"File not found: {fileName}");
            }
        }
    }
}
