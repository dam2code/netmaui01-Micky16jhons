using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Globalization;
using WeatherClient.Models;
using Microsoft.Maui.Controls;

namespace WeatherClient.Converters;

internal class WeatherConditionToImageConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is WeatherType weatherCondition)
        {
            return weatherCondition switch
            {
                WeatherType.Sunny => ImageSource.FromFile("sunny.png"),
                WeatherType.Cloudy => ImageSource.FromFile("cloud.png"),
                _ => ImageSource.FromFile("question.png")
            };
        }

        return ImageSource.FromFile("question.png");
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException(); // No se usa en este caso
    }
}
