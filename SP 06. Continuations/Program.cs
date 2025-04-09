// Continuations

#region ContinueWith OnlyOnRanToCompletation
//var firstTask = new Task<int>(() => TaskMethod("First Task", 3));
//var secondTask = new Task<int>(() => TaskMethod("Second Task", 5));

//firstTask.ContinueWith((t) =>
//{
//    Console.WriteLine("ContinueWith task start");
//    Console.WriteLine($"Task result - {t.Result}");
//    Console.WriteLine($@"Id = {Thread.CurrentThread.ManagedThreadId}
//IsThreadPool = {Thread.CurrentThread.IsThreadPoolThread}
//IsBackground = {Thread.CurrentThread.IsBackground}
//");
//    Console.WriteLine("ContinueWith task end");
//}, TaskContinuationOptions.OnlyOnRanToCompletion);

//secondTask.ContinueWith((t) =>
//{
//    OtherMethod();
//}, TaskContinuationOptions.NotOnCanceled | TaskContinuationOptions.NotOnFaulted);

//firstTask.Start();
//secondTask.Start();
//for (int i = 0; i < 10; i++)
//{
//    Console.WriteLine($"Main thread - {i}");
//    Thread.Sleep(100);
//}
//Task.WaitAll(firstTask, secondTask);
//Console.WriteLine("End...");
#endregion


#region ContinueWith OnlyOnFaulted
//try
//{
//    var firstTask = new Task<int>(() => TaskMethod("First Task", 3));


//    firstTask.ContinueWith((t) =>
//    {
//        OtherMethod();
//    }, TaskContinuationOptions.OnlyOnFaulted);


//    firstTask.Start();

//    for (int i = 0; i < 10; i++)
//    {
//        Console.WriteLine($"Main thread - {i}");
//        Thread.Sleep(100);
//    }
//    firstTask.Wait();
//    Console.WriteLine("End...");
//}
//catch (Exception ex)
//{

//    Console.WriteLine(ex.Message);
//}
//Console.ReadKey();
#endregion

#region ContinueWith with Thread
//var firstTask = new Task<int>(() => TaskMethod("First Task", 3));


//firstTask.ContinueWith((t) =>
//{
//    Console.WriteLine("ContinueWith task start");
//    Console.WriteLine($"Task result - {t.Result}");
//    Console.WriteLine($@"Id = {Thread.CurrentThread.ManagedThreadId}
//IsThreadPool = {Thread.CurrentThread.IsThreadPoolThread}
//IsBackground = {Thread.CurrentThread.IsBackground}
//");
//    Console.WriteLine("ContinueWith task end");
//}, TaskContinuationOptions.OnlyOnRanToCompletion | TaskContinuationOptions.LongRunning);

//firstTask.Start();

//for (int i = 0; i < 10; i++)
//{
//    Console.WriteLine($"Main thread - {i}");
//    Thread.Sleep(100);
//}
//Task.WaitAll(firstTask);
//Console.WriteLine("End...");
#endregion

#region ContinueWith ExecuteSynchronously
//var firstTask = new Task<int>(() => TaskMethod("First Task", 3));


//firstTask.ContinueWith((t) =>
//{
//    Console.WriteLine("ContinueWith task start");
//    Console.WriteLine($"Task result - {t.Result}");
//    Console.WriteLine($@"Id = {Thread.CurrentThread.ManagedThreadId}
//IsThreadPool = {Thread.CurrentThread.IsThreadPoolThread}
//IsBackground = {Thread.CurrentThread.IsBackground}
//");
//    Console.WriteLine("ContinueWith task end");
//}, TaskContinuationOptions.OnlyOnRanToCompletion | TaskContinuationOptions.ExecuteSynchronously);

//firstTask.Start();

//for (int i = 0; i < 10; i++)
//{
//    Console.WriteLine($"Main thread - {i}");
//    Thread.Sleep(100);
//}
//Task.WaitAll(firstTask);
//Console.WriteLine("End...");
#endregion


#region Task.Status
// Created
// WaitingForActivation
// WaitingToRun
// Running
// WaitingForChildrenToComplete
// RanToCompletion
// Canceled
// Faulted
var firstTask = new Task<int>(() => TaskMethod("First Task", 3));

try
{
    Console.WriteLine(firstTask.Status);
    firstTask.Start();
    while (true)
    {
        Console.WriteLine(firstTask.Status);
        Thread.Sleep(100);
        if (firstTask.IsCompleted) break;
    }
    firstTask.Wait();
    Console.WriteLine(firstTask.Status);
}
catch (Exception)
{
    Console.WriteLine(firstTask.Status);
}

#endregion

int TaskMethod(string message, int seconds)
{
    Console.WriteLine($@"Task - {message} running
Id = {Thread.CurrentThread.ManagedThreadId}
IsThreadPool = {Thread.CurrentThread.IsThreadPoolThread}
IsBackground = {Thread.CurrentThread.IsBackground}
");
    Thread.Sleep(TimeSpan.FromSeconds(seconds));
    throw new Exception("Any exception");
    Console.WriteLine($"Task - {message} end.");
    return seconds * 10;
}

void OtherMethod()
{
    Console.WriteLine($"Other method start.");
    Console.WriteLine($@"Id = {Thread.CurrentThread.ManagedThreadId}
IsThreadPool = {Thread.CurrentThread.IsThreadPoolThread}
IsBackground = {Thread.CurrentThread.IsBackground}
");
    Console.WriteLine($"Other method end.");
}
