namespace ObserverDotNetPattern.Entities
{
    public class WeatherData
    {
        private float _temperature;
        private float _humidity;
        private float _pressure;

        public WeatherData(float temperature, float humidity, float pressure)
        {
            _temperature = temperature;
            _humidity = humidity;
            _pressure = pressure;
        }

        public float GetTemperature { get { return _temperature; } }
        public float GetHumidity { get { return _humidity; } }
        public float GetPressure { get { return _pressure; } }
    }
}
