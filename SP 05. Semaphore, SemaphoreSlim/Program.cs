#region Semaphore internal
//Semaphore semaphore = new(3, 3);
//for (int i = 0; i < 30; i++)
//{
//    ThreadPool.QueueUserWorkItem(Some, semaphore);
//}
//Console.ReadLine();

//void Some(object state)
//{
//    var s = state as Semaphore;
//    bool st = false;
//    while (!st)
//    {
//        if (s.WaitOne(500))
//        {
//            try
//            {
//                Thread.Sleep(1);
//                Console.WriteLine($"mr.{Thread.CurrentThread.ManagedThreadId} take key");
//                Thread.Sleep(3000);
//            }
//            finally
//            {
//                Thread.Sleep(1);
//                st = true;
//                Console.WriteLine($"mr.{Thread.CurrentThread.ManagedThreadId} return key");
//                s.Release();


//            }
//        }
//        else
//        {
//            Thread.Sleep(1);
//            Console.WriteLine($"mr.{Thread.CurrentThread.ManagedThreadId}, soryy no keys yet");
//        }

//    }

//}

#endregion

#region Semaphore external
//Semaphore semaphore = new(10, 10, "Salam");
//for (int i = 0; i < 30; i++)
//{
//    ThreadPool.QueueUserWorkItem(Some, semaphore);
//}
//Console.ReadLine();

//void Some(object state)
//{
//    var s = state as Semaphore;
//    bool st = false;
//    while (!st)
//    {
//        if (s.WaitOne(500))
//        {
//            try
//            {
//                Console.ForegroundColor = ConsoleColor.Red;
//                Console.WriteLine($"mr.{Thread.CurrentThread.ManagedThreadId} take key");
//                Thread.Sleep(3000);
//            }
//            finally
//            {
//                Console.ForegroundColor = ConsoleColor.Green;
//                st = true;
//                Console.WriteLine($"mr.{Thread.CurrentThread.ManagedThreadId} return key");
//                s.Release();
//            }
//        }
//        else
//        {
//            Thread.Sleep(1000);
//            Console.ForegroundColor = ConsoleColor.White;
//            Console.WriteLine($"mr.{Thread.CurrentThread.ManagedThreadId}, sorry no keys yet");
//        }

//    }

//}

#endregion

#region SemaphoreSlim
SemaphoreSlim semaphore = new(3, 3);
for (int i = 0; i < 30; i++)
{
    ThreadPool.QueueUserWorkItem(Some, semaphore);
}
Console.ReadLine();

void Some(object state)
{
    var s = state as SemaphoreSlim;
    bool st = false;
    while (!st)
    {
        if (s.Wait(500))
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"mr.{Thread.CurrentThread.ManagedThreadId} take key");
                Thread.Sleep(3000);
            }
            finally
            {
                Console.ForegroundColor = ConsoleColor.Green;
                st = true;
                Console.WriteLine($"mr.{Thread.CurrentThread.ManagedThreadId} return key");
                s.Release();
            }
        }
        else
        {
            Thread.Sleep(1000);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"mr.{Thread.CurrentThread.ManagedThreadId}, sorry no keys yet");
        }

    }

}

#endregion