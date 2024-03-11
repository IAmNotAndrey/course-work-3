using ParaPen.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Ink;
using System.Windows.Media;
using static ParaPen.Helpers.InkCanvasMethods;

namespace ParaPen.Helpers;

public static class InkPenHelper
{
	/// <summary>
	/// Рисует на inkCanvas линию. Изменяет координаты inkPen на toOffset
	/// </summary>
	public static void DrawLine(this InkPen pen, Vector toOffset, InkCanvas inkCanvas)
	{
		Point startPoint = pen.CurCords;
		// Изменяем координаты и заносим в переменную конечную точку
		Point endPoint = pen.MoveOffset(toOffset);

		Stroke line = GetStrokeLine(startPoint, endPoint, pen.DrawingAttributes);
		inkCanvas.Strokes.Add(line);
	}
}
