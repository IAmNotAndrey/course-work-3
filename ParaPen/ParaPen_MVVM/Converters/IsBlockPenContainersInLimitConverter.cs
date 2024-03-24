using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;
using static ParaPen.Models.StaticResources.AppConfig;

namespace ParaPen.Converters;

public class IsBlockPenContainersInLimitConverter : IValueConverter
{
	private readonly uint _limit = BLOCK_DIAGRAM_LIMIT;

	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		return ((IEnumerable<object>)value).Count() < _limit;
		//bool b = a < _limit;
		//return b;
		//IEnumerable<object> ie = ((ListBox)value).Items.Cast<object>();
		//return ie.Count() < _limit;
	}

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}
