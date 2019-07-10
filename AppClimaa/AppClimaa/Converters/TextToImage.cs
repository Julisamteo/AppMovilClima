using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace AppClimaa.Converters
{
    public class TextToImage : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string weather = value as string;
            string path = string.Empty;
            switch(weather)
            {
                case "clear-day":
                    path = "Sunny";
                    break;
                case "clear-night":
                    path = "Sunny";
                    break;
                case "rain":
                    path = "Drizzle";
                    break;
                case "snow":
                    path = "Snow";
                    break;
                case "sleet":
                    path = "Haze";
                    break;
                case "wind":
                    path = "Haze";
                    break;
                case "fog":
                    path = "Cloudy";
                    break;
                case "cloudy":
                    path = "Cloudy";
                    break;
                case "partly-cloudly-day":
                    path = "MostlyCloudy";
                    break;
            }
            return path;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
