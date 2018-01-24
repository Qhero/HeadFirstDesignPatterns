namespace ObserverPattern.Interfaces
{
    public interface IObserver
    {
        /// <summary>
        /// Update new values of the Observer.
        /// </summary>
        /// <param name="temp">Temperature.</param>
        /// <param name="humidity">Humidity percentqge in the air.</param>
        /// <param name="pressure">Air pressure.</param>
        void Update(float temp, float humidity, float pressure);
    }
}
