using System.Diagnostics;

int operationCount = 35500;
var watch = new Stopwatch();

watch.Start();
UseThread(operationCount);
watch.Stop();
Console.WriteLine($"{watch.ElapsedMilliseconds} milliseconds.");
watch.Reset();

watch.Start();
UseThreadPool(operationCount);
watch.Stop();
Console.WriteLine($"{watch.ElapsedMilliseconds} milliseconds.");
watch.Reset();

void UseThread(int operationCount)
{
    using (var count = new CountdownEvent(operationCount))
    {
        Console.WriteLine("Threads...");
        for (int i = 0; i < operationCount; i++)
        {
            var thread = new Thread(() =>
            {
                Thread.Sleep(1);
                //Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId}");
                count.Signal();
            });
            thread.Start();
        }
        count.Wait();
        Console.WriteLine();
    }
}

void UseThreadPool(int operationCount)
{
    List<int> threadsIds = new();
    using (var count = new CountdownEvent(operationCount))
    {
        Console.WriteLine("\tThreadPool...");
        for (int i = 0; i < operationCount; i++)
        {

            ThreadPool.QueueUserWorkItem(o =>
            {
                Thread.Sleep(1);
                //Console.WriteLine($"\tThread {Thread.CurrentThread.ManagedThreadId}");
                if (!threadsIds.Contains(Thread.CurrentThread.ManagedThreadId))
                {
                    threadsIds.Add(Thread.CurrentThread.ManagedThreadId);
                }
                count.Signal();
            });
        }
        count.Wait();
        Console.WriteLine($"\t{threadsIds.Count}");
    }
}
