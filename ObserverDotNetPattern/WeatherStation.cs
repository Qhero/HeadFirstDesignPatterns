using ObserverDotNetPattern.Business;
using ObserverDotNetPattern.Entities;
using System;

namespace ObserverDotNetPattern
{
    class WeatherStation
    {
        static void Main(string[] args)
        {
            var subject = new WeatherMonitor();

            var currentDisplay = new CurrentConditionsDisplay(subject);
            var forecastDisplay = new ForecastDisplay(subject);
            var statsDisplay = new StatisticsDisplay(subject);
            var heatIndexDisplay = new HeatIndexDisplay(subject);

            //simulating sending data 
            subject.SetMeasurements(20.1f, 70, 104.2f);
            subject.SetMeasurements(18.5f, 80, 101.3f);
            subject.SetMeasurements(18.0f, 75, 101.3f);

            Console.Read();
        }
    }
}
