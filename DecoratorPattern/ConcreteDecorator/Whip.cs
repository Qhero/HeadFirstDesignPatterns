using DecoratorPattern.Component;
using DecoratorPattern.Decorator;

namespace DecoratorPattern.ConcreteDecorator
{
    public class Whip : CondimentDecorator
    {
        private Beverage _beverage;

        public Whip(Beverage beverage):base(beverage)
        {
            _beverage = beverage;
        }

        public override double Cost()
        {
            //delegating the call to the object we are decorating so that it can compute the cost, then we add the cost.
            return _beverage.Cost() + .10;
        }

        public override string GetDescription()
        {
            //delegating to the object we are decorating to get its description, then concatening with ", Mocha"
            return _beverage.GetDescription() + ", Whip";
        }
    }
}
