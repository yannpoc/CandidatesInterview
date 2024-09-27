using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace InterviewTest.App
{
	public class HealthIndexColorConverter:IValueConverter
	{
		private Dictionary<HealthIndex,Brush> _colors= new Dictionary<HealthIndex, Brush>()
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
