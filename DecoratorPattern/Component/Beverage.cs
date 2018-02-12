namespace DecoratorPattern.Component
{
    public abstract class Beverage
    {
        protected string description = "Unknow Beverage";

        /// <summary>
        /// Description of the beverage
        /// </summary>
        /// <returns></returns>
        public virtual string GetDescription()
        {
            return description;
        }

        /// <summary>
        /// Cost of the beverage.
        /// </summary>
        /// <returns></returns>
        public abstract double Cost();
    }
}
