using ParaPen.Models;
using ParaPen.Models.Enums;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Ink;
using static ParaPen.Helpers.InkCanvasMethods;
using static ParaPen.Models.StaticResources.AppConfig;

namespace ParaPen.Helpers;

public static class InkPenHelper
{
	/// <summary>
	/// Рисует на <paramref name="inkCanvas"/> линию. Смещает координаты <paramref name="pen"/> на <paramref name="toOffset"/>
	/// </summary>
	public static void DrawLine(this InkPen pen, Vector toOffset, InkCanvas inkCanvas)
	{
		Point startPoint = pen.CurCords;
		// Изменяем координаты и заносим в переменную конечную точку
		Point endPoint = pen.MoveOffset(toOffset);

		Stroke line = GetStrokeLine(startPoint, endPoint, pen.DrawingAttributes);
		inkCanvas.Strokes.Add(line);
	}

	public static Action GetActionOutOfPenActions(double stepValue, PenActions penAction, Directions direction, InkPen inkPen, InkCanvas inkCanvas)
	{
		Vector vectorStep = DirectionVectorDict[direction] * stepValue;

		Action action = penAction switch
		{
			PenActions.Move => () => inkPen.MoveOffset(vectorStep),
			PenActions.Draw => () => inkPen.DrawLine(vectorStep, inkCanvas),
			_ => throw new ArgumentException(null, nameof(penAction)),
		};

		return action;
	}
}
