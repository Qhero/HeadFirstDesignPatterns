using System;
using ObserverPattern.Business;

namespace ObserverPattern
{
    class WeatherStation
    {
        static void Main(string[] args)
        {
            WeatherData weatherData = new WeatherData();

            var currentDisplay = new CurrentConditionDisplay(weatherData);
            var forecastDisplay = new ForecastDisplay(weatherData);
            var statsDisplay = new StatisticsDisplay(weatherData);

            //simulating sending data 
            weatherData.SetMeasurements(20.1f, 70, 104.2f);
            weatherData.SetMeasurements(18.5f, 80, 101.3f);
            weatherData.SetMeasurements(18.0f, 75, 101.3f);

            Console.ReadLine();
        }
    }
}
