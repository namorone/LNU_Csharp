using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;  
            var v1 = new Vehicle("Toyota    ", 135, 4, 1600);
            var v2 = new Vehicle("Hyundai   ", 108, 8, 2500);
            var v3 = new Vehicle("Ford      ", 120, 6, 1800);

            var t1 = new Truck("Hyundai   ", 170, 6, 5000, 3000);
            var t2 = new Truck("Mercedes  ", 625, 10, 9202, 3000);
            var t3 = new Truck("Renault   ", 380, 6, 9742, 9000);
            var t4 = new Truck("Volkswagen", 2800, 10, 9000, 2500);

            var c1 = new Car("Tesla     ", 2800, 4, 2000, 7);
            var c2 = new Car("Audi      ", 261, 4, 1545, 5);
            var c3 = new Car("Opel      ", 103, 4, 1296, 5);
            var c4 = new Car("Ferrari   ", 661, 4, 1475, 5);

            var b1 = new Bus("Škoda     ", 150, 4, 11500, 27, 10);
            var b2 = new Bus("BFM       ", 250, 4, 18000, 101, 12);
            var b3 = new Bus("Ikarus    ", 326, 6, 15630, 28, 56);

            var autopark = new[] { v1, v2, v3, t1, t2, t3, t4, c1, c2, c3, c4, b1, b2, b3 };

            Console.WriteLine("Tsk А");
            foreach (var item in autopark)
            {
                Console.WriteLine(item.Info());
            }

            Console.WriteLine("\n \nTаsk Б");

            
            uint capacity=0;
            foreach (var item in autopark)
            {
                if (item.GetType() == typeof(Truck))
                {
                    var elem = (Truck)item;
                    capacity += elem.Carrying_capacity;
                    

                }
            }
            Console.WriteLine("Загальна вантажопiдйомнiсть  : " + capacity);

            Console.WriteLine("\n \nTаsk В ");

            var Ordered = autopark.OrderByDescending(i => i.Power);

            Console.WriteLine("Перелiк авто, якi мають найбiльшу потужнiсть: ");
           
            //Console.WriteLine(Ordered.First().Info());
            var max = Ordered.First();
            var p = max.Power;
            var mp = new List<Vehicle> { };
            foreach (var i in Ordered)
            {
                if(i.Power==p)
                {
                    mp.Add(i);
                }
            }
            foreach (var i in mp)
            {
                Console.WriteLine(i.Info());
            }

            Console.WriteLine("\n \nTаsk Г ");

            uint Caunt_passengers = 0;
            foreach (var item in autopark)
            {
                if (item.GetType() == typeof(Car) )
                {
                    var elem = (Car)item;
                    Caunt_passengers += elem.Count_sit_places;


                }
                else if (item.GetType() == typeof(Bus))
                {
                    var elem = (Bus)item;
                    Caunt_passengers += elem.Count_sit_places + elem.Count_stend_places;
                }
            }
            Console.WriteLine("Кiлькiсть пасажирiв, яку можна одночасно перевезти усiма транс-портними засобами автопарку : " + Caunt_passengers);
        }



    }



    class Vehicle
    {
        public string Mark { get; set; }
        public uint Power { get; set; }
        public uint Count_whell { get; set; }
        public uint Wegiht { get; set; }

        public Vehicle(string mark = "", uint power = 0, uint count_whell = 0, uint wegiht = 0)
        {
            Mark = mark;
            Power = power;
            Count_whell = count_whell;
            Wegiht = wegiht;

        }

        public virtual string Info()
        {
            return  "Mark =" + Mark + "     Power =" + Power + "      Count_whell =" + Count_whell + "      Wegiht =" + Wegiht;
        }
        
    }
    class Truck : Vehicle
    {
        //uint сarrying_capacity;
        public uint Carrying_capacity { get; set; }
        //{
        //    get { return сarrying_capacity; } set { сarrying_capacity = value; } 
        //}

        public Truck(string mark = "", uint power = 0, uint count_whell = 0, uint wegiht = 0, uint carrying_capacit = 0)
        : base(mark, power, count_whell, wegiht)
        {
            Carrying_capacity = carrying_capacit;
        }
        public override string Info()
        {
            return base.Info() + "      Carrying_capacity =" + Carrying_capacity;
        }
        
    }

    class Car : Vehicle
    {
        public uint Count_sit_places { get; set; }

        public Car(string mark = "", uint power = 0, uint count_whell = 0, uint wegiht = 0, uint count_sit_places = 0)
        : base(mark, power, count_whell, wegiht)
        {
            Count_sit_places = count_sit_places;
        }
        public override string Info()
        {
            return base.Info() + "   Count_sit_places =" +Count_sit_places;
        }
    }

    class Bus : Car
    {
        public uint Count_stend_places { get; set; }
        public Bus(string mark = "", uint power = 0, uint count_whell = 0, uint wegiht = 0, uint count_sit_places = 0, uint count_stend_places = 0)
        : base(mark, power, count_whell, wegiht, count_sit_places)
        {
            Count_stend_places = count_stend_places;
        }
        public override string Info()
        {
            return base.Info() + "    Count_stend_places =" +Count_stend_places;
        }

    }

}