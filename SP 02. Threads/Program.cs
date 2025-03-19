// Threads

//Console.WriteLine(Thread.CurrentThread.ManagedThreadId);



Thread thread1 = new Thread(() =>
{
    for (int i = 0; i < 1000000; i++)
    {
        Console.WriteLine($"\t{i}. My own thread: {Thread.CurrentThread.ManagedThreadId} " +
            $"isBackgroundThread = {Thread.CurrentThread.IsBackground}");
    }
});
Thread thread2 = new Thread(Some);

//thread1.IsBackground = true;

//thread1.Priority = ThreadPriority.Highest;
//thread2.Priority = ThreadPriority.Lowest;
thread1.Start();
thread2.Start();

for (int i = 0; i < 10; i++)
{
    Console.WriteLine($"{i}. Main thread: ThreadId = {Thread.CurrentThread.ManagedThreadId} " 
        + $"isBackgroundThread = {Thread.CurrentThread.IsBackground}");
}

//thread1.Join(); // Chaqiran threadin cahqirilan background thread-i gozlemesi 
ConsoleKeyInfo key = default;
//while (true)
//{
//    key = Console.ReadKey();
//    if (key.Key == ConsoleKey.Enter)
//    {
//        thread1.Interrupt();
//        break;
//    }
//}
Console.WriteLine("End");
void Some()
{
    for (int i = 0; i < 100; i++)
    {
        Console.WriteLine($"\t\t{i}. My own thread in Some method: ThreadId = {Thread.CurrentThread.ManagedThreadId}" +
            $"isBackgroundThread = {Thread.CurrentThread.IsBackground}");
    }
}
