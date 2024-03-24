
// N1

class Progream
{
    static readonly string filePath = "result.txt";
    static readonly ManualResetEvent generationComplete = new ManualResetEvent(false);

    static void Main(string[] args)
    {
        Thread generatorThread = new Thread(GenerateNumbers);
        generatorThread.Start();

        Thread sumThread = new Thread(SumNumbers);
        sumThread.Start();

        Thread productThread = new Thread(ProductNumbers);
        productThread.Start();
    }

    static void GenerateNumbers()
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                int num1 = random.Next(1, 100);
                int num2 = random.Next(1, 100);
                writer.WriteLine($"{num1} {num2}");
                Thread.Sleep(1000);
            }
        }
        Console.WriteLine("Generation complete.");
        generationComplete.Set();
    }

    static void SumNumbers()
    {
        generationComplete.WaitOne();

        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(' ');
                    int num1 = int.Parse(parts[0]);
                    int num2 = int.Parse(parts[1]);
                    int sum = num1 + num2;
                    writer.WriteLine($"Sum: {sum}");
                }
            }
        }
        Console.WriteLine("Sum calculation complete.");
    }

    static void ProductNumbers()
    {
        generationComplete.WaitOne();

        using (StreamWriter writer = new StreamWriter(filePath,true))
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(' ');
                    int num1 = int.Parse(parts[0]);
                    int num2 = int.Parse(parts[1]);
                    int product = num1 * num2;
                    writer.WriteLine($"Product: {product}");
                }
            }
        }
        Console.WriteLine("Product calculation complete.");
    }
    
}


// N2
//
// class Bus
// {
//     public int Number { get; }
//     public int Capacity { get; }
//     public int Passengers { get; private set; }
//
//     public Bus(int number, int capacity)
//     {
//         Number = number;
//         Capacity = capacity;
//     }
//
//     public void Arrive(int passengers)
//     {
//         Passengers += passengers;
//         Console.WriteLine($"Bus {Number} has arrived at the stop. Passengers on board: {Passengers}");
//     }
//
//     public void Depart()
//     {
//         Console.WriteLine($"Bus {Number} has left the stop. Passengers on board: {Passengers}");
//         Passengers = 0;
//     }
// }
//
// class BusStop
// {
//     public int Passengers { get; private set; }
//
//     public void AddPassengers(int count)
//     {
//         Passengers += count;
//         Console.WriteLine($"{count} passengers appeared at the stop. Total passengers at the stop: {Passengers}");
//     }
//
//     public int RemovePassengers(int count)
//     {
//         if (Passengers >= count)
//         {
//             Passengers -= count;
//             return count;
//         }
//         else
//         {
//             int passengersToBoard = Passengers;
//             Passengers = 0;
//             return passengersToBoard;
//         }
//     }
// }
//
// class Program
// {
//     static readonly BusStop _busStop = new BusStop();
//     private static readonly Random _random = new Random();
//
//     static void Main(string[] args)
//     {
//         _busStop.AddPassengers(5);
//         
//         Bus bus333 = new Bus(333, 15);
//         Bus bus444 = new Bus(444, 20);
//
//         Thread bus333th = new Thread(() => BusRoutine(bus333));
//         Thread bus444th = new Thread(() => BusRoutine(bus444));
//         
//         bus333th.Start();
//         bus444th.Start();
//     }
//
//     static void BusRoutine(Bus bus)
//     {
//         while (true)
//         {
//             int initialPassengers = _random.Next(1, 11);
//             
//             int passengersToBoard = Math.Min(_busStop.Passengers, bus.Capacity);
//             bus.Arrive(passengersToBoard);
//             _busStop.AddPassengers(initialPassengers);
//             _busStop.RemovePassengers(passengersToBoard);
//             
//             Thread.Sleep(_random.Next(1000,3000));
//             bus.Depart();
//             
//             Thread.Sleep(_random.Next(3000,6000));
//         }
//     }
//     
// }