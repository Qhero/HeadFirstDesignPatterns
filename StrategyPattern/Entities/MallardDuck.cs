using StrategyPattern.Behaviors;
using System;

namespace StrategyPattern.Entities
{
    public class MallardDuck : Duck
    {
        public MallardDuck()
        {
            _quackBehavior = new Quack();
            _flyBehavior = new FlyWithWings();
        }

        public override void Display()
        {
            Console.WriteLine("I'm real Mallard duck!");
        }
    }
}
