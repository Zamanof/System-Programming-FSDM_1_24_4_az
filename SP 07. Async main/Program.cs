using System.Net;

namespace SP_07._Async_main;

internal class Program
{
    static WebClient client = new();
    static string url = @"https://turbo.az/";
    //static void Main(string[] args)
    //{
    //    Console.WriteLine(SomeAsync().Result);
    //}

    static async Task Main(string[] args)
    {
        //Console.WriteLine(await SomeAsync());
        Console.WriteLine(await client.DownloadStringTaskAsync(url));
    }

    static async Task<string> SomeAsync()
    {
        return await client.DownloadStringTaskAsync(url);
    }
}
