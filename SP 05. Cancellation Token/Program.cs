// Cancellation token

#region Thread interrupt
//Thread thread = new(Download);
//thread.Start();

//var key = Console.ReadKey();

//if (key.Key == ConsoleKey.Enter)
//{
//    Console.WriteLine("Downloading process cancel!");
//    thread.Interrupt();
//}
//void Download(object obj)
//{
//    Console.WriteLine("Downloading start...");
//    Thread.Sleep(1000);
//    for (int i = 0; i < 100; i++)
//    {
//        Console.WriteLine($"{i}%");
//        Thread.Sleep(100);
//        Console.Clear();
//    }
//    Console.WriteLine("Downloading end...");
//}
#endregion

#region CancellationToken with return
//using CancellationTokenSource cts = new();
//CancellationToken cancellationToken = cts.Token;


//ThreadPool.QueueUserWorkItem(o =>
//{
//    Download(cancellationToken);
//});

//var key = Console.ReadKey();

//if (key.Key == ConsoleKey.Enter)
//{
//    cts.Cancel();
//    Thread.Sleep(1000);
//    Console.WriteLine("Downloading process cancel!");

//}
//Console.ReadKey();
//void Download(CancellationToken token)
//{
//    Console.WriteLine("Downloading start...");
//    Thread.Sleep(1000);
//    for (int i = 0; i < 100; i++)
//    {
//        if (token.IsCancellationRequested) return;
//        Console.WriteLine($"{i}%");
//        Thread.Sleep(100);
//        Console.Clear();
//    }
//    Console.WriteLine("Downloading end...");
//}
#endregion

#region CancellationToken with exception
using CancellationTokenSource cts = new();
CancellationToken cancellationToken = cts.Token;


ThreadPool.QueueUserWorkItem(o =>
{
    try
    {
        Download(cancellationToken);
    }
    catch (OperationCanceledException ex)
    {
        Console.WriteLine(ex.Message);
        Console.WriteLine("Downloading process cancel!");
    }

});

var key = Console.ReadKey();

if (key.Key == ConsoleKey.Enter)
{
    cts.Cancel();
    Thread.Sleep(1000);
}
Console.ReadKey();
void Download(CancellationToken token)
{
    Console.WriteLine("Downloading start...");
    Thread.Sleep(1000);
    for (int i = 0; i < 100; i++)
    {
        token.ThrowIfCancellationRequested();
        Console.WriteLine($"{i}%");
        Thread.Sleep(100);
        Console.Clear();
    }
    Console.WriteLine("Downloading end...");
}
#endregion