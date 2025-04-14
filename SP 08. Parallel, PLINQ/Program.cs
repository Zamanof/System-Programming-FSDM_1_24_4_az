// Parallel, PLINQ


using System.Collections.Concurrent;
using System.Diagnostics;

Console.WriteLine();

List<Student> students = new List<Student>();

for (int i = 0; i < 100000000; i++)
{
    students.Add(new Student()
    {
        Id = i + 1,
        FirstName = Faker.NameFaker.FirstName(),
        LastName = Faker.NameFaker.LastName(),
        Age = Faker.NumberFaker.Number(18, 60),
        Mark = Faker.NumberFaker.Number(10, 120) / 10.0,
        Email = Faker.InternetFaker.Email()
    });
}


#region Task wait, when, continue
// var t1 = Task.Run(() =>
//{
//    for (int i = 0; i < students.Count / 2; i++)
//    {
//        students[i].Group = "FSDM_1_24_4_az";
//        Thread.Sleep(10);
//    }
//});

//var t2 = Task.Run(() =>
//{
//    for (int i = students.Count / 2; i < students.Count; i++)
//    {
//        students[i].Group = "FSDM_1_24_4_az";
//        Thread.Sleep(10);
//    }
//});

//t1.Wait();
//t2.Wait();
//Task.WaitAll(t1, t2);
//Task.WhenAll(
//    t1,
//    t2,
//    WriteDataLog(),
//    SendEmailNotification(),
//    SendSMSNotification())
//    .ContinueWith(t =>
//    {
//        Console.WriteLine("Continue with task");
//    });

//Task.WaitAll(
//    Task.Run(() =>
//{
//    for (int i = 0; i < students.Count / 2; i++)
//    {
//        students[i].Group = "FSDM_1_24_4_az";
//        Thread.Sleep(1);
//    }
//}),

//Task.Run(() =>
//{
//    for (int i = students.Count / 2; i < students.Count; i++)
//    {
//        students[i].Group = "FSDM_1_24_4_az";
//        Thread.Sleep(1);
//    }
//}));
//Console.ReadKey();
// Console.WriteLine("End");

//Task WriteDataLog()=>Task.Delay(500);
//Task SendEmailNotification()=>Task.Delay(700);
//Task SendSMSNotification()=>Task.Delay(300);
#endregion

#region Parallel
//Parallel.For(0, students.Count,new ParallelOptions { MaxDegreeOfParallelism=3}, i =>
//{
//    students[i].Group = "FSDM_1_24_4_az";
//    Console.WriteLine($@"
//ThreadId:     {Thread.CurrentThread.ManagedThreadId}
//IsThreadPool: {Thread.CurrentThread.IsThreadPoolThread},
//IsBackground: {Thread.CurrentThread.IsBackground}
//");
//});
//object sync = new();
//Stopwatch stopwatch = new();
//stopwatch.Start();

//for (int i = 0; i < students.Count; i++)
//{
//    students[i].Group = "FSDM_1_24_4_az";
//    Thread.Sleep(1);

//}
//var syncFor = stopwatch.ElapsedTicks;
//stopwatch.Restart();
//stopwatch.Start();

//Parallel.For(0, students.Count, i =>
//{
//    students[i].Group = "FSDM_1_24_4_az";
//    Thread.Sleep(1);
//});
//var parallelFor = stopwatch.ElapsedTicks;
//stopwatch.Stop();

//Console.WriteLine($"Synchrony for: {syncFor}");
//Console.WriteLine($"Parallel for: {parallelFor}");
#endregion

#region PLINQ
//object sync = new();
//Stopwatch sw = new();
//sw.Start();
//var parallelCount = 0;
//Parallel.ForEach(students, student =>
//{
//    if (student.FirstName.Length + student.LastName.Length > 15 && student.Email.ToLower().EndsWith("@gmail.com"))
//    {
//        //lock (sync)
//        //{
//        //    parallelCount++;
//        //}
//        Interlocked.Increment(ref parallelCount);
//        //Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
//    }
//});
//var parallelTicks = sw.ElapsedTicks;
//sw.Restart();

//// LINQ
//var linqCount = students
//    .Count(student => student.FirstName.Length + student.LastName.Length > 15 && student.Email.ToLower().EndsWith("@gmail.com"));
//var linqTicks = sw.ElapsedTicks;
//sw.Restart();


////PLINQ

//var pLinqCount = students
//    .AsParallel()
//    .Count(student => student.FirstName.Length + student.LastName.Length > 15 && student.Email.ToLower().EndsWith("@gmail.com"));

//var pLinqTicks = sw.ElapsedTicks;
//sw.Stop();

//Console.WriteLine($"Linq Tick: {linqTicks}; Count = {linqCount}");
//Console.WriteLine($"Parallel tick: {parallelTicks}; Count = {parallelCount}");
//Console.WriteLine($"PLINQ tick: {pLinqTicks}; Count = {pLinqCount}");
#endregion

#region PLINQ VS LINQ VS Parallel with list
//Stopwatch sw = new();
//sw.Start();
//List<string> namesParallel = [];
//object sync = new();
//Parallel.ForEach(students, student =>
//{
//    if (student.FirstName.Length + student.LastName.Length > 15 && student.Email.ToLower().EndsWith("@gmail.com"))
//    {
//        lock (sync)
//        {
//            namesParallel.Add($"{student.FirstName}  {student.LastName}");
//        }
//    }
//});

//var parallelTicks = sw.ElapsedTicks;
//sw.Restart();

//var namesLinq = students
//    .Where(student => student.FirstName.Length + student.LastName.Length > 15 && student.Email.ToLower().EndsWith("@gmail.com"))
//    .Select(student => $"{student.FirstName} {student.LastName}")
//    .ToList();

//var linqTicks = sw.ElapsedTicks;
//sw.Restart();

//var namesPLinq = students
//    .AsParallel()
//    .Where(student => student.FirstName.Length + student.LastName.Length > 15 && student.Email.ToLower().EndsWith("@gmail.com"))
//    .Select(student => $"{student.FirstName} {student.LastName}")
//    .ToList();
//var pLinqTicks = sw.ElapsedTicks;
//sw.Stop();
////Console.WriteLine(namesParallel.Count);
////Console.WriteLine(namesLinq.Count);
////Console.WriteLine(namesPLinq.Count);

//Console.WriteLine($"Linq Tick: {linqTicks} ");
//Console.WriteLine($"Parallel tick: {parallelTicks}");
//Console.WriteLine($"PLINQ tick: {pLinqTicks}");
#endregion


#region PLINQ VS LINQ VS Parallel with Thread Safe Collections
Stopwatch sw = new();
sw.Start();
ConcurrentBag<string> namesParallel = [];
object sync = new();
Parallel.ForEach(students, student =>
{
    if (student.FirstName.Length + student.LastName.Length > 15 && student.Email.ToLower().EndsWith("@gmail.com"))
    {
            namesParallel.Add($"{student.FirstName}  {student.LastName}");
    }
});

var parallelTicks = sw.ElapsedTicks;
sw.Restart();

var namesLinq = students
    .Where(student => student.FirstName.Length + student.LastName.Length > 15 && student.Email.ToLower().EndsWith("@gmail.com"))
    .Select(student => $"{student.FirstName} {student.LastName}")
    .ToList();

var linqTicks = sw.ElapsedTicks;
sw.Restart();

var namesPLinq = students
    .AsParallel()
    .Where(student => student.FirstName.Length + student.LastName.Length > 15 && student.Email.ToLower().EndsWith("@gmail.com"))
    .Select(student => $"{student.FirstName} {student.LastName}")
    .ToList();
var pLinqTicks = sw.ElapsedTicks;
sw.Stop();
Console.WriteLine(namesParallel.Count);
Console.WriteLine(namesLinq.Count);
Console.WriteLine(namesPLinq.Count);

Console.WriteLine($"Linq Tick: {linqTicks} ");
Console.WriteLine($"Parallel tick: {parallelTicks}");
Console.WriteLine($"PLINQ tick: {pLinqTicks}");
#endregion