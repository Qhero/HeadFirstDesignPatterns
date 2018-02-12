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
            var size = _beverage.GetSize();

            double cost = _beverage.Cost();
            switch (size)
            {
                case Size.TALL:
                    cost += .05;
                    break;
                case Size.GRANDE:
                    cost += .10;
                    break;
                case Size.VENTI:
                    cost += .15;
                    break;
            }

            return cost;
        }

        public override string GetDescription()
        {
            //delegating to the object we are decorating to get its description, then concatening with ", Mocha"
            return _beverage.GetDescription() + ", Whip";
        }
    }
}
