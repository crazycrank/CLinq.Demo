using System;
using CLinq.Demo.Demos;

namespace CLinq.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonDemo.Run();
            BestRevenueStoresDemo.Run();
            RevenuePerYearDemo.Run();

            Console.In.Read();
        }
    }
}
