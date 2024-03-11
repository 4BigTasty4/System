//AutoResetEvent 

// class Program
// {
//     static AutoResetEvent resetEvent = new AutoResetEvent(false);
//
//     static void Main(string[] args)
//     {
//         Thread th = new Thread(Status);
//
//         th.Start();
//         resetEvent.Set();
//         th.Join();
//     }
//
//     static void Status()
//     {
//         Console.WriteLine("The worker thread is waiting...");
//         resetEvent.WaitOne();
//         Console.WriteLine("Workflow has resumed!");
//     }
// }


//ManualResetEvent 

// class Program
// {
//     static ManualResetEvent resetEvent = new ManualResetEvent(false);
//
//     static void Main(string[] args)
//     {
//         Thread th = new Thread(Status);
//
//         th.Start();
//         resetEvent.Set();
//         Thread.Sleep(1000);
//         resetEvent.Reset();
//         th.Join();
//     }
//
//     static void Status()
//     {
//         Console.WriteLine("The worker thread is waiting...");
//         resetEvent.WaitOne();
//         Console.WriteLine("Workflow has resumed!");
//     }
// }