using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace ParaPen.Converters;

public class LoopPathStartConverter : IMultiValueConverter
{
	public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
	{
		if (values == null || values.Length != 2)
			return DependencyProperty.UnsetValue;

		if (!(values[0] is Point source) || !(values[1] is Point target))
			return DependencyProperty.UnsetValue;

		// Вычисляем среднюю точку между начальной и конечной вершинами
		double centerX = (source.X + target.X) / 2;
		double centerY = (source.Y + target.Y) / 2;

		// Возвращаем точку, смещенную от средней точки на некоторое расстояние
		// Можно экспериментировать с этим расстоянием для получения желаемого эффекта
		return new Point(centerX, centerY - 50); // Смещение петли вверх от средней точки
	}

	public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}
