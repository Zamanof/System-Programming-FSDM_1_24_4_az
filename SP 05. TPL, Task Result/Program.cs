Task<int> task = Task.Run(()
                            => TaskReturnMethod("Task1", 3));

var result = task.Result;
Console.WriteLine(result);
Console.WriteLine("End of code...");

int TaskReturnMethod(string message, int second)
{
    Console.WriteLine($@"Task - {message} running
Id = {Thread.CurrentThread.ManagedThreadId}
IsThreadPool = {Thread.CurrentThread.IsThreadPoolThread}
IsBackground = {Thread.CurrentThread.IsBackground}
");
    Thread.Sleep(TimeSpan.FromSeconds(second));
    return second * 10;
}