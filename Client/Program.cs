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
                        Console.WriteLine("Product name: ");
                        product.Product = Console.ReadLine();
                        Console.WriteLine("Product price: ");
                        product.Price = Convert.ToInt32(Console.ReadLine());

                        result = await client.PostAsJsonAsync("product", product);
                        var response = await result.Content.ReadAsStringAsync();
                        Console.WriteLine(response == "True" ? "Created product" : "Error");

                        break;
                    case "2":
                        var content = await client.GetFromJsonAsync<List<ProductModel>>("products");
                        Console.Clear();
                        Console.WriteLine("--- Products ---");
                        foreach (var c in content)
                        {
                            Console.WriteLine($"\nProduct: {c.Product}, Price: {c.Price}");
                        }
                        break;
                    case "3":
                        //res = await client.PutAsync("put/product");
                        break;
                    case "4":
                        //res = await client.DeleteAsync("product");
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