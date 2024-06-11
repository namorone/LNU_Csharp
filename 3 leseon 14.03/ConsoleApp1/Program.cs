// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System;
using System.Drawing;
using System.Linq;
using System.Collections;
using System.Security.Cryptography.X509Certificates;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace заняття_14_03_2023
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            var w_c1 = new WaterCounter(234, 7, 5970, 6004);
//            var w_c2 = new WaterCounter();
//            var w_c3 = new WaterCounter(44, 12, 678, 730);
//            var w_c4 = new WaterCounter(6, 6, 555, 590);
//            var w_c5 = new WaterCounter(119, 6, 220, 278);
//            var w_c6 = new WaterCounter(365, 9, 765, 800);
//            WaterCounter[] waterCounters = new WaterCounter[] { w_c1, w_c2, w_c3, w_c4, w_c5, w_c6 };
//            // a
//            Console.Write("Input number of month: ");
//            //int NumberOfMonth = Convert.ToInt32(Console.ReadLine());
//            //foreach (var waterCounter in waterCounters)
//            //{
//            //    if (waterCounter.getNumberOfMonth() == NumberOfMonth)
//            //    {
//            //        Console.WriteLine("Room " + waterCounter.getNumberOfRoom() + " - " + waterCounter.usedWater());
//            //    }
//            //}
//            Array.Sort(waterCounters, new WaterCounterRoomComparer<WaterCounter>());
//            foreach (var waterCounter in waterCounters)
//            {
//                Console.WriteLine("Room " + waterCounter.getNumberOfRoom() + " - " + waterCounter.usedWater());
//            }
//        }
//    }
//    public class WaterCounter
//    {
//        int number_of_room;
//        int number_of_month;
//        int previous_counter;
//        int current_counter;
//        public WaterCounter(int number_of_room, int number_of_month, int previous_counter, int current_counter)
//        {
//            this.number_of_room = number_of_room;
//            this.number_of_month = number_of_month;
//            this.current_counter = current_counter;
//            this.previous_counter = previous_counter;
//        }
//        public WaterCounter()
//        {
//            number_of_room = 1;
//            number_of_month = 1;
//            current_counter = 1;
//            previous_counter = 0;
//        }
//        public int getNumberOfRoom()
//        {
//            return number_of_room;
//        }
//        public int getNumberOfMonth()
//        {
//            return number_of_month;
//        }
//        public void setNumberOfMonth(int number_of_month)
//        {
//            this.number_of_month = number_of_month;
//        }
//        public int getPreviousCounter()
//        {
//            return previous_counter;
//        }
//        public int getCurrentCounter()
//        {
//            return current_counter;
//        }
//        public int usedWater()
//        {
//            return current_counter - previous_counter;
//        }
//    }
//    public class WaterCounterRoomComparer<T> : IComparer<T> where T : WaterCounter
//    {
//        public int Compare(T first, T second)
//        {
//            return first.usedWater().CompareTo(second.usedWater());
//        }
//    }
//}




namespace заняття_14_03_2023_wc_v2
{
    class Program
    {
        static void Main(string[] args)
        {
            var w_c1 = new WaterCounter(234, 7, 5970, 6004);
            var w_c2 = new WaterCounter();
            var w_c3 = new WaterCounter(44, 12, 678, 730);
            var w_c4 = new WaterCounter(6, 6, 555, 590);
            var w_c5 = new WaterCounter(119, 6, 220, 278);
            var w_c6 = new WaterCounter(365, 9, 765, 800);
            WaterCounter[] waterCounters = new WaterCounter[] { w_c1, w_c2, w_c3, w_c4, w_c5, w_c6 };
            var wotherCauntersL = new List<WaterCounter> { w_c1, w_c2, w_c3, w_c4, w_c5, w_c6 };
            wotherCauntersL.Sort();
            //// a
            ////Console.Write("Input number of month: ");
            ////int NumberOfMonth = Convert.ToInt32(Console.ReadLine());
            ////foreach (var waterCounter in waterCounters)
            ////{
            ////    if (waterCounter.getNumberOfMonth() == NumberOfMonth)
            ////    {
            ////        Console.WriteLine("Room " + waterCounter.getNumberOfRoom() + " - " + waterCounter.usedWater());
            ////    }
            ////}
            // б
            //Array.Sort(waterCounters, new WaterCounterRoomComparer<WaterCounter>());
            //foreach (var waterCounter in waterCounters)
            //{
            //    Console.WriteLine("Room " + waterCounter.getNumberOfRoom() + " - " + waterCounter.usedWater());
            //}
            //в
            wotherCauntersL.Sort( new WaterCounterRoomComparer<WaterCounter>(), wotherCauntersL);
            foreach (var waterCounter in wotherCauntersL)
            {
                Console.WriteLine("Room " + waterCounter.getNumberOfRoom() + " - " + waterCounter.usedWater());
            }

        }
    }
    public class WaterCounter : IComparable<WaterCounter>
    {
        int number_of_room;
        int number_of_month;
        int previous_counter;
        int current_counter;
        public WaterCounter(int number_of_room, int number_of_month, int previous_counter, int current_counter)
        {
            this.number_of_room = number_of_room;
            this.number_of_month = number_of_month;
            this.current_counter = current_counter;
            this.previous_counter = previous_counter;
        }
        public WaterCounter()
        {
            number_of_room = 1;
            number_of_month = 1;
            current_counter = 1;
            previous_counter = 0;
        }
        public int getNumberOfRoom()
        {
            return number_of_room;
        }
        public int getNumberOfMonth()
        {
            return number_of_month;
        }
        public void setNumberOfMonth(int number_of_month)
        {
            this.number_of_month = number_of_month;
        }
        public int getPreviousCounter()
        {
            return previous_counter;
        }
        public int getCurrentCounter()
        {
            return current_counter;
        }
        public int usedWater()
        {
            return current_counter - previous_counter;
        }
        public int CompareTo(WaterCounter other)
        {
            return current_counter.CompareTo(other.current_counter);
        }


    }
    public class WaterCounterRoomComparer<T> : IComparer<T> where T : WaterCounter
    {
        public int Compare(T first, T second)
        {
            return first.usedWater().CompareTo(second.usedWater());
        }
    }
}