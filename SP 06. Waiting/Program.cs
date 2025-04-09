// Waiting

#region Single Wait
//var firstTask = new Task<int>(()=>TaskMethod("First Task", 15));
//firstTask.Start();
//for (int i = 0; i < 10; i++)
//{
//    Console.WriteLine($"Main thread - {i}");
//    Thread.Sleep(1000);
//}
//firstTask.Wait();
//Console.WriteLine("End of code");
#endregion

#region WaitAll
//var firstTask = new Task<int>(() => TaskMethod("First Task", 3));
//var secondTask = new Task<int>(() => TaskMethod("second Task", 5));
//firstTask.Start();
//secondTask.Start();
//for (int i = 0; i < 10; i++)
//{
//    Console.WriteLine($"Main thread - {i}");
//    Thread.Sleep(100);
//}
//Task.WaitAll(firstTask, secondTask);
//Console.WriteLine("End of code");
#endregion

#region WaitAny
//var firstTask = new Task<int>(() => TaskMethod("First Task", 3));
//var secondTask = new Task<int>(() => TaskMethod("second Task", 2));
//firstTask.Start();
//secondTask.Start();
//for (int i = 0; i < 10; i++)
//{
//    Console.WriteLine($"Main thread - {i}");
//    Thread.Sleep(100);
//}
//Task.WaitAny(firstTask, secondTask);
//Console.WriteLine("End of code");
#endregion

int TaskMethod(string message, int seconds)
{
    Console.WriteLine($@"Task - {message} running
Id = {Thread.CurrentThread.ManagedThreadId}
IsThreadPool = {Thread.CurrentThread.IsThreadPoolThread}
IsBackground = {Thread.CurrentThread.IsBackground}
");
    Thread.Sleep(TimeSpan.FromSeconds(seconds));
    Console.WriteLine($"Task - {message} end.");
    return seconds * 10;
}