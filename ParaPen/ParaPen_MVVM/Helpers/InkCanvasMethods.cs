using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using ParaPen.Models;

namespace ParaPen.Helpers;

public static class InkCanvasMethods
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

    public static bool IsStrokeAtPoint(Point point, InkCanvas inkCanvas)
    {
        return inkCanvas.Strokes.Any(s => ((Point[])s.StylusPoints).Contains(point));
    }

	/// <param name="delta">Допустимая погрешность</param>
	[Obsolete]
    public static bool IsStrokeAtPoint(Point point, InkCanvas inkCanvas, double delta = 0)
	{
		foreach (var stroke in inkCanvas.Strokes)
		{
			foreach (var p in (Point[])stroke.StylusPoints)
			{
				if (Math.Abs(p.X - point.X) <= delta && Math.Abs(p.Y - point.Y) <= delta)
				{
					return true;
				}
			}
		}
		return false;
	}

	///// <summary>
	///// Рисует на inkCanvas линию. Изменяет координаты inkPen на toOffset
	///// </summary>
	//public static void DrawLine(Vector toOffset, InkPen pen, InkCanvas inkCanvas)
	//{
	//	Point startPoint = pen.CurCords;
	//	// Изменяем координаты и заносим в переменную
	//	Point endPoint = pen.MoveOffset(toOffset);

	//	Stroke line = GetStrokeLine(startPoint, endPoint, pen.DrawingAttributes);
	//	inkCanvas.Strokes.Add(line);
	//}
}
