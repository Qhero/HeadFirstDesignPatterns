
namespace ObserverPattern.Helper
{
    public static class TemperatureConverter
    {
        /// <summary>
        /// Convert Celsius to Fahrenheit.
        /// </summary>
        /// <param name="celsius">Temperature in C°</param>
        /// <returns></returns>
        public static float ToFahrenheit(this float celsius)
        {
            return ((9f / 5f) * celsius) + 32;
        }

        /// <summary>
        /// Convert Fahrenheit to Celsius.
        /// </summary>
        /// <param name="fahrenheit">Temperature in F°</param>
        /// <returns></returns>
        public static float ToCelsius(this float fahrenheit)
        {
            return (5f / 9f) * (fahrenheit - 32);
        }
    }
}
