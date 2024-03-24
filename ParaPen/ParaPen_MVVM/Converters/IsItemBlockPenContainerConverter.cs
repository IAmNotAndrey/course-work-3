using System.Globalization;
using System;
using System.Windows.Data;
using ParaPen.Models;

namespace ParaPen.Converters;

public class IsItemBlockPenContainerConverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		return value is BlockPenContainer;
	}

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}
