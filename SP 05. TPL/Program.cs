/*
 CLR Thread Pool - u "kimler" istifade edir
1. ThreadPool
2. Windows Timer
3. TPL (Task Parallel Library)
4. Asynchronous methods (.BeginInvoke(), .EndInvoke()) - obsolete 
*/

// TPL - Task Parallel Library

// Thread -> ThreadPool -> TPL

Task task1 = new Task(() =>
{
    TaskMethod("Task1");
});

Task task2 = new Task(() =>
{
    TaskMethod("Task2");
});

Task task3 = Task.Run(() =>
{
    TaskMethod("Task3");
});

var task4 = Task.Factory.StartNew(() =>
{
    TaskMethod("Task4");
});

Task task5 = new(() =>
{
    TaskMethod("Task5");
}, TaskCreationOptions.LongRunning);

task1.Start();
task2.Start();
task5.Start();

Console.ReadKey();

void TaskMethod(string message)
{
    Console.WriteLine($@"Task - {message} running
Id = {Thread.CurrentThread.ManagedThreadId}
IsThreadPool = {Thread.CurrentThread.IsThreadPoolThread}
IsBackground = {Thread.CurrentThread.IsBackground}
");
}