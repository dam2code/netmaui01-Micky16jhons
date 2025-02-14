using System.ComponentModel;

namespace WeatherClient.Models;

public class WeatherData : INotifyPropertyChanged
{
    private double _temperature;
    private double _humidity;
    private double _precipitation;
    private double _wind;

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public double Temperature
    {
        get => _temperature;
        set { _temperature = value; OnPropertyChanged(nameof(Temperature)); }
    }

    public double Humidity
    {
        get => _humidity;
        set { _humidity = value; OnPropertyChanged(nameof(Humidity)); }
    }

    public double Precipitation
    {
        get => _precipitation;
        set { _precipitation = value; OnPropertyChanged(nameof(Precipitation)); }
    }

    public double Wind
    {
        get => _wind;
        set { _wind = value; OnPropertyChanged(nameof(Wind)); }
    }
}