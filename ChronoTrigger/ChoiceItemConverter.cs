using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ChronoTrigger
{
	internal class ChoiceItemConverter : IMultiValueConverter
	{
		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			var type = int.Parse(values[1]?.ToString() ?? "0");
			return new Tuple<Item, ChoiceWindow.ChoiceType>((Item)values[0], (ChoiceWindow.ChoiceType)type);
		}

		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
