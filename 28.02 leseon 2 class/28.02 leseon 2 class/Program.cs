// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System;
using System.Drawing;
using System.Linq;
class WotherCaunter
{
    int number_of_flat ;
    int month;
    int previous_counter_readings;
    int counter_readings;
    public WotherCaunter(int n=0,int p_c=0, int c=0,int m = 0)
    {
        number_of_flat = n;
        month = m;
        previous_counter_readings = p_c;
        counter_readings = c;
    }
    
    public int get_number_of_flat() 
    {
        return number_of_flat;
    }

    public int get_month() 
    {
        return month; 
    }
    public int get_previous_counter_readings()
    {
        return previous_counter_readings;
    }

    public int get_counter_readings() 
    {
        return counter_readings;
    }

    public int usedWater()
    {
        return counter_readings - previous_counter_readings;
    }
}



class Watco 
{
    public static void Main(string[] args)
    {
        var wc1 = new WotherCaunter();
        var wc2 = new WotherCaunter(2,23,32,5);
        var wc3 = new WotherCaunter(4, 3, 5, 7);
        var wc4 = new WotherCaunter(7, 345, 349, 7);
        var wc5 = new WotherCaunter(7, 349, 351, 9);
        
        var wotherCaunters = new List<WotherCaunter> {wc1, wc2, wc3, wc4, wc5};

        int month = 7;
        for (int i=0;i < wotherCaunters.Count;i++) 
        {
            if (wotherCaunters[i].get_month() == month)
            {
                Console.WriteLine(wotherCaunters[i].get_number_of_flat() + ": " + wotherCaunters[i].usedWater());
            }
        }
        Console.ReadLine();
    }


}