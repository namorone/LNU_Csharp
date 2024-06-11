using System;
using System.Collections;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace Program
{
    class Program
    {
        public static void ReadTextByStreamReader(string path)
        {
            using (var reader = new StreamReader(path))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }
        public static void addTextByStreamWriter(string path)
        {
            if (File.Exists(path)) File.Delete(path);
            var fs = new FileStream(path, FileMode.CreateNew);

            using (var writer = new StreamWriter(fs))
            {
                writer.WriteLine("Fuck");
                writer.Write("Fuck you");
            }
        }
        static void Main(string[] args)
        {
            string line;
            var lstVehicles = new List<TwoWheelVehicle>();
            string path1 = "C:\\Users\\user\\source\\Прога С#\\linq 11.04.2023\\linq 11.04.2023\\1.csv";
            string path2 = "C:\\Users\\user\\source\\Прога С#\\linq 11.04.2023\\linq 11.04.2023\\2.csv";
            string path3 = "C:\\Users\\user\\source\\Прога С#\\linq 11.04.2023\\linq 11.04.2023\\3.csv";

            using (FileStream stream = File.OpenRead(path1))
            {
                System.IO.StreamReader file = new System.IO.StreamReader(@path1);
                while ((line = file.ReadLine()) != null)
                {
                    string[] arrtibutes = line.Split(',');
                    lstVehicles.Add(new TwoWheelVehicle(Convert.ToString(arrtibutes[0]),
                    Convert.ToDouble(arrtibutes[1]),
                    Convert.ToUInt32(arrtibutes[2]),
                    Convert.ToUInt32(arrtibutes[3])));
                }
            }

            using (FileStream stream = File.OpenRead(path2))
            {
                System.IO.StreamReader file = new System.IO.StreamReader(@path2);
                while ((line = file.ReadLine()) != null)
                {
                    string[] arrtibutes = line.Split(',');
                    lstVehicles.Add(new WithDieselEngine(
                        Convert.ToString(arrtibutes[0]),
                        Convert.ToDouble(arrtibutes[1]),
                        Convert.ToUInt32(arrtibutes[2]),
                        Convert.ToUInt32(arrtibutes[3]),
                        Convert.ToUInt32(arrtibutes[4])));
                }
            }

            using (FileStream stream = File.OpenRead(path3))
            {
                System.IO.StreamReader file = new System.IO.StreamReader(@path3);
                while ((line = file.ReadLine()) != null)
                {
                    string[] attributes = line.Split(',');
                    lstVehicles.Add(new WithElectroEngine(
                        Convert.ToString(attributes[0]),
                        Convert.ToDouble(attributes[1]),
                        Convert.ToUInt32(attributes[2]),
                        Convert.ToUInt32(attributes[3]),
                        Convert.ToUInt32(attributes[4])
                        ));
                }
            }


            Console.WriteLine("Task A\nUnsorted: ");
            foreach (var i in lstVehicles) { Console.WriteLine(i); }

            Console.WriteLine("\nSorted: \n");

            var sortedVehicles = from v in lstVehicles
                                 orderby v.Mark
                                 select v;
            foreach (var i in sortedVehicles) { Console.WriteLine(i); }

            
            Console.WriteLine("Task Б");
            var powers = from v in lstVehicles
                         select v.EnginePower;
            double maxPow = powers.Max();
            var mostPower = from v in lstVehicles
                            where v.EnginePower == (from v1 in lstVehicles
                                              select v1.EnginePower).Max()
                            select v;
            foreach (var item in mostPower)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Task B");
            var maxDieselEngine = lstVehicles.OfType<WithDieselEngine>().OrderByDescending(x => x.EngineCapacity).First();
            Console.WriteLine("Найпотужніший мотоцикл з дизельним двигуном:\n" + maxDieselEngine);
            var maxElectroEngine = lstVehicles.OfType<WithElectroEngine>().OrderByDescending(x => x.EngineVolume).First();
            Console.WriteLine("Найпотужніший мотоцикл з електродвигуном:\n" + maxElectroEngine);




            Console.ReadLine();
        }
    }
    public class TwoWheelVehicle
    {
        public string Mark { get; set; }
        public double EnginePower { get; set; }
        public uint MaxSpeed { get; set; }
        public uint MaxWeight { get; set; }
        public TwoWheelVehicle(string mark, double ngnpwr, uint whlnmbr, uint wght)
        {
            Mark = mark;
            EnginePower = ngnpwr;
            MaxSpeed = whlnmbr;
            MaxWeight = wght;
        }
        public override string ToString()
        {
            return "Mark: " + Mark + " EnginePower: " + EnginePower + " MaxSpeed: " + MaxSpeed + " Weight: " + MaxWeight;
        }
    }
    public class WithDieselEngine : TwoWheelVehicle
    {
        public uint EngineCapacity { get; set; }
        public WithDieselEngine(string mark, double ngnpwr, uint whlnmbr, uint wght, uint v) : base(mark, ngnpwr, whlnmbr, wght)
        {
            EngineCapacity = v;
        }
        public override string ToString()
        {
            return "Mark: " + Mark + " EnginePower: " + EnginePower + " WheelNumber: " + MaxSpeed + " MaxWeight: " + MaxWeight + " EngineCapacity: " + EngineCapacity;
        }
    }
    public class WithElectroEngine : TwoWheelVehicle
    {
        public uint EngineVolume { get; set; }
        public WithElectroEngine(string mark, double ngnpwr, uint whlnmbr, uint wght, uint ngnvlm) : base(mark, ngnpwr, whlnmbr, wght)
        {
            EngineVolume = ngnvlm;
        }
        public override string ToString()
        {
            return "Mark: " + Mark + " EnginePower: " + EnginePower + " WheelNumber: " + MaxSpeed + " Weight: " + MaxWeight + " EngineVolume: " + EngineVolume;
        }
    }
    public class VehicleComparer<T> : IComparer<T> where T : TwoWheelVehicle
    {
        public int Compare(T x, T y)
        {
            return x.Mark.CompareTo(y.Mark);
        }
    }
    public class TruckComparer<T> : IComparer<T> where T : WithDieselEngine
    {
        public int Compare(T x, T y)
        {
            return x.MaxSpeed.CompareTo(y.MaxSpeed);
        }
    }
}

//foreach (var i in sortedVehicles) { Console.WriteLine(i); }

//Console.WriteLine("\nTask B\n");

//var grouped = from v in lstVehicles
//              group v by v.Mark into groups
//              select groups;

//foreach (var i in grouped)
//{
//    foreach (var j in i)
//    {
//        Console.WriteLine(i);
//    }
//}




//Console.WriteLine("\nTask C");

//var trucks = new List<WithDieselEngine>();

//foreach (var i in lstVehicles)
//{
//    if (i.GetType() == typeof(WithDieselEngine))
//    {
//        trucks.Add((WithDieselEngine)i);
//    }
//}

//var mostPowerful = trucks[0];
//foreach (var i in trucks)
//{
//    if (i.EngineCapacity > mostPowerful.EngineCapacity)
//        mostPowerful = i;
//}
//Console.WriteLine("Most Powerful Truck: ");
//Console.WriteLine(mostPowerful);

//var sortedtrucks = trucks.OrderBy(x => x, new TruckComparer<WithDieselEngine>());
//Console.WriteLine("Sorted Trucks by wheelNumber: ");
//foreach (var i in sortedtrucks.Reverse()) { Console.WriteLine(i); }



//    Console.WriteLine("\nTask D");

//    var cars = new List<WithElectroEngine>();

//    foreach (var i in lstVehicles)
//    {
//        if (i.GetType() == typeof(WithElectroEngine))
//        {
//            cars.Add((WithElectroEngine)i);
//        }
//    }

//    var mostSeatable = cars[0];
//    foreach (var i in cars)
//    {
//        if (i.Seats > mostSeatable.Seats)
//        {
//            mostSeatable = i;
//        }
//    }
//    Console.WriteLine("Car with most seats: ");
//    Console.WriteLine(mostSeatable);

//    var sortedCars = cars.OrderBy(x => x, new CarComparer<WithElectroEngine>());
//    Console.WriteLine("Sorted Cars by Seats: ");
//    foreach (var i in sortedCars.Reverse()) { Console.WriteLine(i); }

//}