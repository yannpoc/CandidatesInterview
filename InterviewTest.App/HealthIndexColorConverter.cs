using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace InterviewTest.App
{
    public class HealthIndexColorConverter : IValueConverter
    {
        private readonly Dictionary<HealthIndex, Brush> _colors = new()
        {
            {HealthIndex.Average, Brushes.Yellow },
            {HealthIndex.Bad, Brushes.Red },
            {HealthIndex.Good, Brushes.Green},
            {HealthIndex.Unknown, Brushes.Gray }
        };

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            HealthIndex healthIndex = value as HealthIndex? ?? HealthIndex.Unknown;
            return _colors[healthIndex];
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}