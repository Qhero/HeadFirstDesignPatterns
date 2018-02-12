namespace DecoratorPattern.Component
{
    public abstract class Beverage
    {
        public enum Size { TALL, GRANDE, VENTI };
        //default size
        private Size _size = Size.TALL;

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

        /// <summary>
        /// Set the beverage size.
        /// </summary>
        /// <param name="size"></param>
        public virtual void SetSize(Size size)
        {
            _size = size;
        } 

        /// <summary>
        /// Get the beverage size.
        /// </summary>
        /// <returns></returns>
        public virtual Size GetSize()
        {
            return _size;
        }
    }
}
