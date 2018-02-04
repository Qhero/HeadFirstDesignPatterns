using ObserverDotNetPattern.Entities;
using ObserverDotNetPattern.Helper;
using ObserverDotNetPattern.Interfaces;
using System;

namespace ObserverDotNetPattern.Business
{
    class HeatIndexDisplay : IObserver<WeatherData>, IDisplayElement
    {
        private float _heatIndex;

        private IDisposable unsubscriber;

        public HeatIndexDisplay()
        {
        }

        public HeatIndexDisplay(IObservable<WeatherData> provider)
        {
            Subscribe(provider);
        }

        public void Subscribe(IObservable<WeatherData> provider)
        {
            unsubscriber = provider.Subscribe(this);
        }

        public void Unsubscribe()
        {
            unsubscriber.Dispose();
        }

        public void Display()
        {
            Console.WriteLine("Heat index: Feels like " + _heatIndex + "°C.");
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
            var fahrenheit = value.GetTemperature.ToFahrenheit();
            _heatIndex = ComputeHeatIndex(fahrenheit, value.GetHumidity).ToCelsius();

            Display();
        }

        /// <summary>
        /// Calculate the heat index, the apparent temperature.
        /// </summary>
        /// <param name="t">in F°</param>
        /// <param name="rh">relative humidity</param>
        /// <returns></returns>
        private float ComputeHeatIndex(float t, float rh)
        {
            float index = (float)((16.923 + (0.185212 * t) + (5.37941 * rh) - (0.100254 * t * rh) +
                (0.00941695 * (t * t)) + (0.00728898 * (rh * rh)) +
                (0.000345372 * (t * t * rh)) - (0.000814971 * (t * rh * rh)) +
                (0.0000102102 * (t * t * rh * rh)) - (0.000038646 * (t * t * t)) + (0.0000291583 *
                (rh * rh * rh)) + (0.00000142721 * (t * t * t * rh)) +
                (0.000000197483 * (t * rh * rh * rh)) - (0.0000000218429 * (t * t * t * rh * rh)) +
                0.000000000843296 * (t * t * rh * rh * rh)) -
                (0.0000000000481975 * (t * t * t * rh * rh * rh)));
            return index;
        }
    }
}
