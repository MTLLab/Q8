using System;
using ResponseTimeStatistics;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            var a = DateTime.Now;
            var b = DateTime.Now;
            var time = b - a;

            StatsCollector sc = new StatsCollector();
            sc.pushValue(1);
            sc.pushValue(2);
            sc.pushValue(3);
            sc.pushValue(3);



            double result1 = sc.getAverage();
            double result2 = sc.getMedian();
            Console.Read();
        }
    }
}
