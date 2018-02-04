using ObserverDotNetPattern.Entities;
using System;
using System.Collections.Generic;

namespace ObserverDotNetPattern
{
    public class WeatherMonitor : IObservable<WeatherData>
    {
        private List<IObserver<WeatherData>> _observers;
        public WeatherMonitor()
        {
            _observers = new List<IObserver<WeatherData>>();
        }

        public IDisposable Subscribe(IObserver<WeatherData> observer)
        {
            if (!_observers.Contains(observer))
                _observers.Add(observer);

            return new Unsubscriber(_observers, observer);
        }

        private class Unsubscriber : IDisposable
        {
            private List<IObserver<WeatherData>> _observers;
            private IObserver<WeatherData> _observer;

            public Unsubscriber(List<IObserver<WeatherData>> observers, IObserver<WeatherData> observer)
            {
                this._observers = observers;
                this._observer = observer;
            }

            public void Dispose()
            {
                if (!(_observer == null)) _observers.Remove(_observer);
            }
        }

        /// <summary>
        /// Rather than reading actual weather data from a device, we'll use this method to test our display elements.
        /// </summary>
        /// <param name="temp">Temperature</param>
        /// <param name="humidity">Humidity percentage</param>
        /// <param name="pressure">Air pressure</param>
        public void SetMeasurements(float temp, float humidity, float pressure)
        {
            foreach (var observer in _observers)
            {
                observer.OnNext(new WeatherData(temp, humidity, pressure));
            }
        }

        public void LastNotification()
        {
            foreach (var observer in _observers)
            {
                if (observer != null)
                    observer.OnCompleted();
            }

            _observers.Clear();
        }
    }
}
