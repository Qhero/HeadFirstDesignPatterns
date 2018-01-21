using StrategyPattern.Behaviors;
using System;

namespace StrategyPattern.Entities
{
    public class ModelDuck : Duck
    {
        public ModelDuck()
        {
            _flyBehavior = new FlyNoWay();
            _quackBehavior = new Quack();
        }

        public override void Display()
        {
            Console.WriteLine("I'm a model duck!");
        }
    }
}
