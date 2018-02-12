using DecoratorPattern.Component;
using DecoratorPattern.Decorator;

namespace DecoratorPattern.ConcreteDecorator
{
    public class Mocha : CondimentDecorator
    {
        protected Beverage _beverage;

        public Mocha(Beverage beverage):base(beverage)
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
                    cost += .15;
                    break;
                case Size.GRANDE:
                    cost += .20;
                    break;
                case Size.VENTI:
                    cost += .25;
                    break;
            }

            return cost;
        }

        public override string GetDescription()
        {
            //delegating to the object we are decorating to get its description, then concatening with ", Mocha"
            return _beverage.GetDescription() + ", Mocha";
        }
    }
}
