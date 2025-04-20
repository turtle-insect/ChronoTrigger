using System.Globalization;
using System.Windows.Data;

namespace ChronoTrigger
{
	internal class ItemIDConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var id = (uint)value;
			var name = Info.Instance().Search(Info.Instance().All, id)?.Name;
			if (name == null) name = $"ID : {id}";
			return name;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
