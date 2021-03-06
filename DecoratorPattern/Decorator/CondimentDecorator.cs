﻿using DecoratorPattern.Component;
using System;

namespace DecoratorPattern.Decorator
{
    public abstract class CondimentDecorator : Beverage
    {
        private Beverage _beverage;
        public CondimentDecorator(Beverage beverage)
        {
            _beverage = beverage;
        }

        /// <summary>
        /// Get the description of a beverage.
        /// </summary>
        /// <remarks>We are using the reference Beverage from the concrete decorators</remarks>
        /// <returns></returns>
        public override String GetDescription()
        {
            return _beverage.GetDescription();
        }

        public override Size GetSize()
        {
            return _beverage.GetSize();
        }

        public override void SetSize(Size size)
        {
            _beverage.SetSize(size);
        }
    }
}
