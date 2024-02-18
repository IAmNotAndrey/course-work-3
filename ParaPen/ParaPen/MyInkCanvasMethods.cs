using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;

namespace ParaPen;

public static class MyInkCanvasMethods
{
	public static Stroke GetStrokeLine(System.Windows.Point a, System.Windows.Point b, DrawingAttributes drawingAttributes)
	{
		var points = new StylusPointCollection
		{
			new StylusPoint(a.X, a.Y),
			new StylusPoint(b.X, b.Y)
		};

		Stroke line = new(points)
		{
			DrawingAttributes = drawingAttributes
		};

		return line;
	}
}
