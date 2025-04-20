using System.Globalization;
using System.Windows.Data;

namespace ChronoTrigger
{
	internal class PartyIDConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			uint id = (uint)value;
			if (id == 0x80) return -1;
			return id;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
