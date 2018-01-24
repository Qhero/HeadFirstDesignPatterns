using ObserverPattern.Interfaces;
using System;

namespace ObserverPattern.Business
{
    public class StatisticsDisplay : IObserver, IDisplayElement
    {
        private float _maxTemp = 0.0f;
        private float _minTemp = 60;
        private float _tempSum = 0.0f;
        private int _numOfReadings;
        private ISubject _weatherData;

        public StatisticsDisplay(WeatherData weatherData)
        {
            _weatherData = weatherData;
            _weatherData.RegisterObserver(this);
        }

        public void Update(float temp, float humidity, float pressure)
        {
            //adding new value to the sum in order to get the average.
            _tempSum += temp;
            //counting the number of reading.
            _numOfReadings++;

            //recording the max temperature.
            if (temp > _maxTemp)
            {
                _maxTemp = temp;
            }

            //recording the min temperature.
            if (temp < _minTemp)
            {
                _minTemp = temp;
            }

            Display();
        }

        public void Display()
        {
            Console.WriteLine("Avg/Max/Min temperature = " + Math.Round((_tempSum / _numOfReadings), 1)
            + "C° /" + _maxTemp + "C° /" + _minTemp+ "C°");
        }
    }
}
