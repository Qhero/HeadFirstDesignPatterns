using StrategyPattern.Behaviors;
using StrategyPattern.Entities;
using System;

namespace StrategyPattern
{
    public class SimulatorDuck
    {
        public static void Main(string[] args)
        {
            Duck model = new ModelDuck();

            model.PerformFly();
            model.SetFlyBehavior(new FlyRocketPowered());
            model.PerformFly();

            Console.ReadLine();
        }
    }
}
