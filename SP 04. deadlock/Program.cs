object obj1 = new();
object obj2 = new();

Thread thread1 = new(ObliviousMethod);
Thread thread2 = new(BlindMethod);

thread1.Start();
thread2.Start();



void ObliviousMethod()
{
    Console.WriteLine("ObliviousMethod start...");
    lock (obj1)
    {
        Thread.Sleep(1000);
        lock (obj2)
        {

        }
    }
    Console.WriteLine("ObliviousMethod end...");
}

void BlindMethod()
{
    Console.WriteLine("BlindMethod start...");
    lock (obj2)
    {
        Thread.Sleep(1000);
        lock (obj1)
        {

        }
    }
    Console.WriteLine("BlindMethod end...");
}

