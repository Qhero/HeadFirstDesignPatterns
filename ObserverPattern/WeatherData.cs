using ObserverPattern.Interfaces;
using System.Collections.Generic;

namespace ObserverPattern
{
    public class WeatherData : ISubject
    {
        private List<IObserver> _observers;
        private float _temperature;
        private float _humidity;
        private float _pressure;

        public WeatherData()
        {
            _observers = new List<IObserver>();
        }

        public void NotifyObservers()
        {
            foreach (var obv in _observers)
            {
                obv.Update(_temperature, _humidity, _pressure);
            }
        }

        public void RegisterObserver(IObserver o)
        {
            _observers.Add(o);
        }

        public void RemoveObserver(IObserver o)
        {
            int i = _observers.IndexOf(o);

            if (i >= 0)
                _observers.Remove(o);
        }

        public void MeasurementChanged()
        {
            NotifyObservers();
        }

        /// <summary>
        /// Rather than reading actual weather data from a device, we'll use this method to test our display elements.
        /// </summary>
        /// <param name="temp">Temperature</param>
        /// <param name="humidity">Humidity percentage</param>
        /// <param name="pressure">Air pressure</param>
        public void SetMeasurements(float temp, float humidity, float pressure)
        {
            this._temperature = temp;
            this._humidity = humidity;
            this._pressure = pressure;
            MeasurementChanged();
        }
    }
}
