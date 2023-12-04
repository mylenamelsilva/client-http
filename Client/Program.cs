namespace Client
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            HttpResponseMessage res;
            HttpClient client = new() { BaseAddress = new Uri("http://localhost:8080") };

            Console.WriteLine("Welcome! Choose one option (Number only):");
            Console.WriteLine("\n1. Create a product\n2. List all products\n3. Update a product\n4. Delete a product\n");
            string? option = Console.ReadLine();

            while (option == "")
            {
                Console.WriteLine("The choice isn't valid. Try again.\n");
                option = Console.ReadLine();
            }


            switch(option)
            {
                case "1":
                   //res = await client.PostAsync("post/product");
                    break;
                case "2":
                    res = await client.GetAsync("get/products");
                    break;
                case "3":
                    //res = await client.PutAsync("put/product");
                    break;
                case "4":
                    res = await client.DeleteAsync("delete/product");
                    break;
            }
        }
    }
}