using ObserverDotNetPattern.Entities;
using ObserverDotNetPattern.Interfaces;
using System;

namespace ObserverDotNetPattern.Business
{
    public class StatisticsDisplay : IObserver<WeatherData>, IDisplayElement
    {
        private float _maxTemp = 0.0f;
        private float _minTemp = 60;
        private float _tempSum = 0.0f;
        private int _numOfReadings;

        private IDisposable unsubscriber;

        public StatisticsDisplay()
        {

        }

        public StatisticsDisplay(IObservable<WeatherData> provider)
        {
            Subscribe(provider);
        }

        public void Display()
        {
            Console.WriteLine("Avg/Max/Min temperature = " + Math.Round((_tempSum / _numOfReadings), 1)
            + "C° /" + _maxTemp + "C° /" + _minTemp + "C°");
        }

        public void Subscribe(IObservable<WeatherData> provider)
        {
            unsubscriber = provider.Subscribe(this);
        }

        public void Unsubscribe()
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
            var temp = value.GetTemperature;

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
    }
}
