namespace Client
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            HttpClient client = new() { BaseAddress = new Uri("http://localhost:8080") };
        }
    }
}