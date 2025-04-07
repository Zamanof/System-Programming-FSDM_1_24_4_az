// AutoResetEvent - siqnallama mexanizmi

AutoResetEvent _workEvent = new AutoResetEvent(false);
AutoResetEvent _mainEvent = new AutoResetEvent(false);

// 1. start
Thread thread = new(() =>
{
    SomeProcess(1);
});
thread.Start();
Console.WriteLine("Waiting Some Process");
// 1. End

_workEvent.WaitOne();

// 3. Start
Console.WriteLine("Starting Main Process");

for (int i = 0; i < 10; i++)
{
    Console.WriteLine($"Main proces - {i}");
    Thread.Sleep(TimeSpan.FromSeconds(1));
}
// 3. End
Console.ReadLine();
_mainEvent.Set();

Console.WriteLine("Worker doing some job");

_workEvent.WaitOne();

// 5. start
Console.WriteLine("Complete");
// 5. end



void SomeProcess(int seconds)
{
    // 2. Start
    Console.WriteLine("Starting some process");
    Thread.Sleep(TimeSpan.FromSeconds(seconds));
    Console.WriteLine("Ok");
    // 2. End
    
    Console.ReadLine();
    _workEvent.Set();

    Console.WriteLine("Main process is working");
    _mainEvent.WaitOne();

    // 4. Start
    for (int i = 0; i < 10; i++)
    {
        Console.WriteLine($"Some process - {i}");
        Thread.Sleep(TimeSpan.FromSeconds(i));
    }
    Console.WriteLine("Some Process End");
    // 4. End

    Console.ReadLine();
    _workEvent.Set();
}