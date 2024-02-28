using System.Windows;
using System.Windows.Ink;
using System.Windows.Input;

namespace ParaPen.Models;

public class InkCanvasMethods
{
	public static Stroke GetStrokeLine(Point a, Point b, DrawingAttributes drawingAttributes)
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
