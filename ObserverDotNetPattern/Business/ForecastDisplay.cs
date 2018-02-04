using ObserverDotNetPattern.Entities;
using ObserverDotNetPattern.Interfaces;
using System;

namespace ObserverDotNetPattern.Business
{
    public class ForecastDisplay : IObserver<WeatherData>, IDisplayElement
    {
        //average of normal air pressure is 101.3kPA;
        private float _currentPressure = 101.3f;
        private float _lastPressure;

        private IDisposable unsubscriber;

        public ForecastDisplay()
        {
        }

        public ForecastDisplay(IObservable<WeatherData> provider)
        {
            Subscribe(provider);
        }

        public void Display()
        {
            Console.Write("Forecast: ");
            if (_currentPressure > _lastPressure)
            {
                Console.WriteLine("Improving weather on the way!");
            }
            else if (_currentPressure == _lastPressure)
            {
                Console.WriteLine("Same old bro.");
            }
            else if (_currentPressure < _lastPressure)
            {
                Console.WriteLine("Hoho, get your pancho!");
            }
        }

        public virtual void Subscribe(IObservable<WeatherData> provider)
        {
            unsubscriber = provider.Subscribe(this);
        }

        public virtual void Unsubscribe()
        {
            unsubscriber.Dispose();
        }

        public void OnCompleted()
        {
            Display();
        }

        public void OnError(Exception error)
        {
            //do nothing
        }

        public void OnNext(WeatherData value)
        {
            _lastPressure = _currentPressure;
            _currentPressure = value.GetPressure;
            Display();
        }
    }
}
