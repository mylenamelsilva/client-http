using Client.Model;
using System.Net.Http.Json;

namespace Client
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            HttpResponseMessage result;
            HttpClient client = new() { BaseAddress = new Uri("http://localhost:8080") };
            
            bool running = true;
            Console.WriteLine("Welcome! Choose one option (Number only):");
            while (running)
            {
                Console.WriteLine("\n1. Create a product\n2. List all products\n3. Update a product\n4. Delete a product\n5 - Exit\n");
                string? option = Console.ReadLine();

                while (option == "")
                {
                    Console.WriteLine("The choice isn't valid. Try again.\n");
                    option = Console.ReadLine();
                }

                switch (option)
                {
                    case "1":
                        ProductParams product = new();
                        Console.Write("\nProduct name: ");
                        product.Product = Console.ReadLine();
                        Console.Write("Product price: ");
                        product.Price = Convert.ToDouble(Console.ReadLine());

                        result = await client.PostAsJsonAsync("product", product);
                        var response = await result.Content.ReadAsStringAsync();
                        Console.WriteLine(response == "True" ? "\nCreated product" : "\nError");

                        break;
                    case "2":
                        var content = await client.GetFromJsonAsync<List<ProductModel>>("products");
                        Console.Clear();
                        Console.WriteLine("\n--- Products ---");
                        foreach (var c in content)
                        {
                            Console.WriteLine($"\nID: {c.Id}, Product: {c.Product}, Price: {c.Price}");
                        }
                        break;
                    case "3":
                        ProductModel obj = new();
                        Console.Write("\nProduct id: ");
                        obj.Id = Console.ReadLine();
                        Console.Write("Product name: ");
                        obj.Product = Console.ReadLine();
                        Console.Write("Product price: ");
                        obj.Price = Convert.ToInt32(Console.ReadLine());
                        result = await client.PutAsJsonAsync("product", obj);
                        response = await result.Content.ReadAsStringAsync();
                        Console.WriteLine(response == "True" ? "\nChanged product" : "\nError");
                        break;
                    case "4":
                        Console.Write("\nProduct id: ");
                        string id = Console.ReadLine();
                        result = await client.DeleteAsync($"product/{id}");
                        response = await result.Content.ReadAsStringAsync();
                        Console.WriteLine(response == "True" ? "\nDeleted product" : "\nError");
                        break;
                    case "5":
                        Console.WriteLine("\nExiting the program.");
                        running = false;
                        break;
                }
            }
        }
    }
}