using System;
using System.Collections.Generic;
using InventoryLibrary;

namespace InventoryManager
{
    class Program
    {
        static JSONStorage storage = new JSONStorage();

        static void Main(string[] args)
        {
        
            storage.Load();

            PrintPrompt();

            while (true)
            {
                Console.Write("\nCommand: ");
                string input = Console.ReadLine()?.Trim() ?? string.Empty;

                if (string.Equals(input, "exit", StringComparison.OrdinalIgnoreCase))
                {
                    storage.Save();
                    Console.WriteLine("Exiting Inventory Manager...");
                    break;
                }

                ProcessCommand(input);
            }
        }

        static void PrintPrompt()
        {
            Console.WriteLine("Inventory Manager");
            Console.WriteLine("-------------------------");
            Console.WriteLine("<ClassNames> show all ClassNames of objects");
            Console.WriteLine("<All> show all objects");
            Console.WriteLine("<All [ClassName]> show all objects of a ClassName");
            Console.WriteLine("<Create [ClassName]> create a new object");
            Console.WriteLine("<Show [ClassName object_id]> show an object");
            Console.WriteLine("<Update [ClassName object_id]> update an object");
            Console.WriteLine("<Delete [ClassName object_id]> delete an object");
            Console.WriteLine("<Exit>");
        }

        static void ProcessCommand(string input)
        {
            string[] parts = input.Split(' ', 2);
            string command = parts[0].ToLower();

            switch (command)
            {
                case "classnames":
                    ShowClassNames();
                    break;
                case "all":
                    ShowAll(parts.Length > 1 ? parts[1] : null);
                    break;
                case "create":
                    if (parts.Length > 1) CreateObject(parts[1]);
                    else Console.WriteLine("Please provide a ClassName to create.");
                    break;
                case "show":
                    if (parts.Length > 1) ShowObject(parts[1]);
                    else Console.WriteLine("Please provide a ClassName and object ID to show.");
                    break;
                case "update":
                    if (parts.Length > 1) UpdateObject(parts[1]);
                    else Console.WriteLine("Please provide a ClassName and object ID to update.");
                    break;
                case "delete":
                    if (parts.Length > 1) DeleteObject(parts[1]);
                    else Console.WriteLine("Please provide a ClassName and object ID to delete.");
                    break;
                default:
                    Console.WriteLine("Unknown command. Type a valid command.");
                    break;
            }
        }

        static void ShowClassNames()
        {
            Console.WriteLine("Available Classes:");
            Console.WriteLine("Item, User, Inventory");
        }

        static void ShowAll(string? className = null)
        {
            var objects = storage.All();
            if (className == null)
            {
                foreach (var obj in objects)
                {
                    Console.WriteLine($"{obj.Key}: {obj.Value}");
                }
            }
            else
            {
                foreach (var obj in objects)
                {
                    if (obj.Key.StartsWith(className))
                        Console.WriteLine($"{obj.Key}: {obj.Value}");
                }
            }
        }

        static void CreateObject(string className)
        {
            switch (className.ToLower())
            {
                case "item":
                    Console.Write("Enter name: ");
                    string itemName = Console.ReadLine() ?? string.Empty;
                    if (string.IsNullOrWhiteSpace(itemName))
                    {
                        Console.WriteLine("Name cannot be empty.");
                        return;
                    }
                    Item item = new Item(itemName);
                    storage.New(item);
                    Console.WriteLine($"Created Item: {item}");
                    break;
                case "user":
                    Console.Write("Enter name: ");
                    string userName = Console.ReadLine() ?? string.Empty;
                    if (string.IsNullOrWhiteSpace(userName))
                    {
                        Console.WriteLine("Name cannot be empty.");
                        return;
                    }
                    User user = new User(userName);
                    storage.New(user);
                    Console.WriteLine($"Created User: {user}");
                    break;
                case "inventory":
                    Console.Write("Enter User ID: ");
                    string userId = Console.ReadLine() ?? string.Empty;
                    Console.Write("Enter Item ID: ");
                    string itemId = Console.ReadLine() ?? string.Empty;
                    if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(itemId))
                    {
                        Console.WriteLine("User ID and Item ID cannot be empty.");
                        return;
                    }
                    Console.Write("Enter quantity: ");
                    if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity < 0)
                    {
                        Console.WriteLine("Quantity must be a non-negative integer.");
                        return;
                    }
                    Inventory inventory = new Inventory(userId, itemId, quantity);
                    storage.New(inventory);
                    Console.WriteLine($"Created Inventory: {inventory}");
                    break;
                default:
                    Console.WriteLine($"{className} is not a valid object type.");
                    break;
            }
        }

        static void ShowObject(string input)
        {
            var parts = input.Split(' ');
            if (parts.Length < 2 || string.IsNullOrWhiteSpace(parts[1]))
            {
                Console.WriteLine("Invalid input. Provide a ClassName and object ID.");
                return;
            }

            string key = $"{parts[0]}.{parts[1]}";
            if (storage.All().TryGetValue(key, out object? obj))
            {
                Console.WriteLine(obj);
            }
            else
            {
                Console.WriteLine($"Object {parts[1]} could not be found.");
            }
        }

        static void UpdateObject(string input)
        {
            var parts = input.Split(' ');
            if (parts.Length < 2 || string.IsNullOrWhiteSpace(parts[1]))
            {
                Console.WriteLine("Invalid input. Provide a ClassName and object ID.");
                return;
            }

            string key = $"{parts[0]}.{parts[1]}";
            if (storage.All().TryGetValue(key, out object? obj))
            {
                Console.WriteLine("Enter the property to update:");
                string property = Console.ReadLine() ?? string.Empty;
                Console.WriteLine("Enter the new value:");
                string value = Console.ReadLine() ?? string.Empty;

                var objType = obj.GetType();
                var propInfo = objType.GetProperty(property);
                if (propInfo == null)
                {
                    Console.WriteLine($"{property} does not exist on {parts[0]}.");
                    return;
                }

                try
                {
                    propInfo.SetValue(obj, Convert.ChangeType(value, propInfo.PropertyType));
                    Console.WriteLine($"Updated {key}");
                }
                catch
                {
                    Console.WriteLine($"Failed to update {property} with value {value}.");
                }
            }
            else
            {
                Console.WriteLine($"Object {parts[1]} could not be found.");
            }
        }

        static void DeleteObject(string input)
        {
            var parts = input.Split(' ');
            if (parts.Length < 2 || string.IsNullOrWhiteSpace(parts[1]))
            {
                Console.WriteLine("Invalid input. Provide a ClassName and object ID.");
                return;
            }

            string key = $"{parts[0]}.{parts[1]}";
            if (storage.All().Remove(key))
            {
                Console.WriteLine($"Deleted {key}");
            }
            else
            {
                Console.WriteLine($"Object {parts[1]} could not be found.");
            }
        }
    }
}