using StrategyPattern.Entities;
using System;

namespace StrategyPattern
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Duck mallard = new MallardDuck();
            mallard.PerformFly();
            mallard.PerformQuack();

            Console.ReadLine();
        }
    }
}
