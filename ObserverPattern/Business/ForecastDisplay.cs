using ObserverPattern.Interfaces;
using System;

namespace ObserverPattern.Business
{
    public class ForecastDisplay : IObserver, IDisplayElement
    {
        //average of normal air pressure is 101.3kPA;
        private float _currentPressure = 101.3f;
        private float _lastPressure;
        private ISubject _weatherData;

        public ForecastDisplay(WeatherData weatherData)
        {
            _weatherData = weatherData;
            _weatherData.RegisterObserver(this);
        }

        public void Update(float temp, float humidity, float pressure)
        {
            _lastPressure = _currentPressure;
            _currentPressure = pressure;
            Display();
        }

        public void Display()
        {
            Console.Write("Forecast: ");
            if(_currentPressure > _lastPressure)
            {
                Console.WriteLine("Improving weather on the way!");
            }
            else if (_currentPressure == _lastPressure)
            {
                Console.WriteLine("Same old bro.");
            }
            else if(_currentPressure < _lastPressure)
            {
                Console.WriteLine("Hoho, get your pancho!");
            }
        }
    }
}
