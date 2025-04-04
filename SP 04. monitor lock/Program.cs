#region Albahari examples
//for (int i = 0; i < 10; i++)
//{
//    new Thread(() =>
//    {
//        Console.WriteLine(i);
//    }).Start();
//}

//for (int i = 0; i < 10; i++)
//{
//    int tmp = i;
//    new Thread(() =>
//    {
//        Console.WriteLine(tmp);
//    }).Start();
//}

//string name = "Nadir";
//Thread thread1 = new Thread(() =>
//{
//    Console.WriteLine(name);
//});
//name = "Zaman";
//Thread thread2 = new Thread(() =>
//{
//    Console.WriteLine(name);
//});

//thread1.Start();
//thread2.Start();
#endregion

// Critical section - thread-lerin eyni yaddash sahesine ve ya resursa muracietidir.

#region Critical section problem
//Thread[] threads = new Thread[5];
//for (int i = 0; i< threads.Length; i++)
//{
//    threads[i] = new Thread(() =>
//    {
//        for (int j = 0; j < 1000000; j++)
//        {
//            Counter.Count++;
//        }
//    });
//}
//for (int i = 0; i < threads.Length; i++)
//{
//    threads[i].Start();
//}
////Console.WriteLine(Counter.Count);
//for (int i = 0;i < threads.Length; i++)
//{
//    threads[i].Join();
//}
//Console.WriteLine(Counter.Count);
#endregion

#region Interlocked
//Thread[] threads = new Thread[5];
//for (int i = 0; i < threads.Length; i++)
//{
//    threads[i] = new Thread(() =>
//    {
//        for (int j = 0; j < 1000000; j++)
//        {
//            Interlocked.Increment(ref Counter.Count);
//            if (Counter.Count % 2 == 0)
//            {
//                Interlocked.Increment(ref Counter.Even);
//            }
//        }
//    });
//}
//for (int i = 0; i < threads.Length; i++)
//{
//    threads[i].Start();
//}
////Console.WriteLine(Counter.Count);
//for (int i = 0; i < threads.Length; i++)
//{
//    threads[i].Join();
//}
//Console.WriteLine(Counter.Count);
//Console.WriteLine(Counter.Even);
#endregion

#region Monitor
//Thread[] threads = new Thread[5];
//object obj = new object();
//for (int i = 0; i < threads.Length; i++)
//{
//    threads[i] = new Thread(() =>
//    {
//        for (int j = 0; j < 1000000; j++)
//        {
            //Monitor.Enter(obj);
//            try
//            {
//                Counter.Count++;
//                if (Counter.Count % 2 == 0)
//                {
//                    Counter.Even++;
//                }
//            }
//            finally
//            {

//                Monitor.Exit(obj);
//            }

//        }
//    });
//}
//for (int i = 0; i < threads.Length; i++)
//{
//    threads[i].Start();
//}

//for (int i = 0; i < threads.Length; i++)
//{
//    threads[i].Join();
//}
//Console.WriteLine(Counter.Count);
//Console.WriteLine(Counter.Even);
#endregion

#region lock
//Thread[] threads = new Thread[5];
//object obj = new object();
//for (int i = 0; i < threads.Length; i++)
//{
//    threads[i] = new Thread(() =>
//    {
//        for (int j = 0; j < 1000000; j++)
//        {
//            // lock - monitor syntax sugar
//            /*
             
//                object obj = this.obj;
//                bool lockTaken = false;
//                try
//                {
//                    Monitor.Enter(obj, ref lockTaken);
//                    Counter.Count++;
//                    if (Counter.Count % 2 == 0)
//                    {
//                        Counter.Even++;
//                    }
//                }
//                finally
//                {
//                    if (lockTaken)
//                    {
//                        Monitor.Exit(obj);
//                    }
//                }
             
//             */
//            lock (obj)
//            {
//                Counter.Count++;
//                if (Counter.Count % 2 == 0)
//                {
//                    Counter.Even++;
//                }
//            }
//        }
//    });
//}
//for (int i = 0; i < threads.Length; i++)
//{
//    threads[i].Start();
//}

//for (int i = 0; i < threads.Length; i++)
//{
//    threads[i].Join();
//}
//Console.WriteLine(Counter.Count);
//Console.WriteLine(Counter.Even);
#endregion