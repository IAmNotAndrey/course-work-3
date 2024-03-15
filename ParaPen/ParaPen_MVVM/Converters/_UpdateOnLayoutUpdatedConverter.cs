using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace ParaPen.Converters;

public class _UpdateOnLayoutUpdatedConverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		FrameworkElement element = value as FrameworkElement;

		if (element != null)
		{
			// Подписываемся на событие LayoutUpdated
			element.LayoutUpdated += (sender, e) =>
			{
				// Обновляем привязку
				var expression = element.GetBindingExpression(FrameworkElement.RenderTransformProperty);
				expression?.UpdateTarget();
			};
		}

		return value;
	}

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
		throw new NotSupportedException();
	}
}
