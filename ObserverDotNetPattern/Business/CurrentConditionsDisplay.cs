using ObserverDotNetPattern.Entities;
using ObserverDotNetPattern.Interfaces;
using System;

namespace ObserverDotNetPattern.Business
{
    public class CurrentConditionsDisplay : IObserver<WeatherData>, IDisplayElement
    {
        private float _temperature;
        private float _humidity;

        private IDisposable unsubscriber;

        public CurrentConditionsDisplay()
        {
        }

        public CurrentConditionsDisplay(IObservable<WeatherData> provider)
        {
            Subscribe(provider);
        }

        public void Display()
        {
            Console.WriteLine("Current conditions: " + _temperature + "C° degrees and " + _humidity + "% humidity");
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
            _temperature = value.GetTemperature;
            _humidity = value.GetHumidity;
            Display();
        }
    }
}
