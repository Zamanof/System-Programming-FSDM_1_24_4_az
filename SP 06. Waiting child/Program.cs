var grandFatherTask = new Task<int>(() =>
{
    var fatherTask = Task.Factory.StartNew(() =>
    {
        var grandSonTask = Task.Factory.StartNew(() =>
        {
            TaskReturnMethod("Grandson task", 8);
        }, TaskCreationOptions.AttachedToParent);

        TaskReturnMethod("Father task", 5);

    }, TaskCreationOptions.AttachedToParent);

    return TaskReturnMethod("GrandFather task", 3);
});

grandFatherTask.Start();
Console.WriteLine(grandFatherTask.Result);
Console.WriteLine("End");

int TaskReturnMethod(string message, int second)
{
    Console.WriteLine($"{message} TaskReturnMethod start");
    Console.WriteLine($@"Task - {message} running
Id = {Thread.CurrentThread.ManagedThreadId}
IsThreadPool = {Thread.CurrentThread.IsThreadPoolThread}
IsBackground = {Thread.CurrentThread.IsBackground}
");
    Thread.Sleep(TimeSpan.FromSeconds(second));
    Console.WriteLine($"{message} TaskReturnMethod end");
    return second * 10;
}
