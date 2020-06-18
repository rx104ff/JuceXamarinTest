using System;
using System.Globalization;
using Xamarin.Forms;

namespace JuceTest
{
    public class FrequencyConvertor: IValueConverter
    {
        private const float minFrequency = 0f;
        private const float frequencyStep = 40;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int integer)
            {
                return minFrequency + (integer * frequencyStep) + " Hz";
            }
            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return " ";
        }
    }
}
