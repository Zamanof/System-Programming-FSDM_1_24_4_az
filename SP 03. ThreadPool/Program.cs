// ThreadPool
//ThreadPool.GetAvailableThreads(out int workerCount, out int complCount);
//Console.WriteLine(workerCount);
//Console.WriteLine(complCount);


Console.WriteLine("Main method start...");

//Console.WriteLine($"\tMain isBackground: {Thread.CurrentThread.IsBackground}");
//Console.WriteLine($"\tMain isThreadPoolThread: {Thread.CurrentThread.IsThreadPoolThread}");

ThreadPool.QueueUserWorkItem(AsyncOperations, "Salam");
ThreadPool.QueueUserWorkItem(o=> { SomeOperations(); });

Console.ReadKey();
Console.WriteLine("Main method end...");

void AsyncOperations(object state)
{
    Console.WriteLine("\tAsyncOperations method start...");
    Console.WriteLine($"\tState: {state}");
    Console.WriteLine($"\tAsyncOperations thread id: {Thread.CurrentThread.ManagedThreadId}");
    Console.WriteLine($"\tAsyncOperations isBackground: {Thread.CurrentThread.IsBackground}");
    Console.WriteLine($"\tAsyncOperations isThreadPoolThread: {Thread.CurrentThread.IsThreadPoolThread}");
    Console.WriteLine("\tAsyncOperations method end...");
}

void SomeOperations()
{
    Console.WriteLine("\t\tSomeOperations method start...");
    Console.WriteLine($"\t\tSomeOperations thread id: {Thread.CurrentThread.ManagedThreadId}");
    Console.WriteLine($"\t\tSomeOperations isBackground: {Thread.CurrentThread.IsBackground}");
    Console.WriteLine($"\t\tSomeOperations isThreadPoolThread: {Thread.CurrentThread.IsThreadPoolThread}");
    Console.WriteLine("\t\tSomeOperations method end...");
}


