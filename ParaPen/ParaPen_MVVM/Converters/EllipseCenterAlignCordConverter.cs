using System;
using System.Globalization;
using System.Windows.Data;

namespace ParaPen.Converters;

public class EllipseCenterAlignCordConverter : IValueConverter
{
	/// <param name="parameter">{height or width}</param>
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		int size = int.Parse(parameter.ToString()!);
		double offset = size / 2;
		double cord = double.Parse(value.ToString()!);

		return cord - offset;
	}


	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}
