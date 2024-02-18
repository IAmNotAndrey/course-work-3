using ParaPen.EventArgs;
using ParaPen.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Ink;
using static ParaPen.MyInkCanvasMethods;

namespace ParaPen;

public class InkPen : IInkPen
{
	public event EventHandler<PositionEventArgs> PenPositionChanged;
	public event EventHandler OnDispose;

	public System.Windows.Point CurCords { get; set; } = new(0, 0);
	public DrawingAttributes DrawingAttributes { get; init; }

	private readonly InkCanvas _inkCanvas;


	public InkPen(InkCanvas inkCanvas, DrawingAttributes drawingAttributes, IUserViewMover userViewMover)
	{
		_inkCanvas = inkCanvas;
		DrawingAttributes = drawingAttributes;

		userViewMover.UserViewOffsetChanged += MovePen;
	}

	// note : возможно, стоит использовать другие методы для реализации "удаления" объекта
	public void Dispose()
	{
		OnDispose?.Invoke(this, System.EventArgs.Empty);
		//throw new NotImplementedException();
	}


	public void DrawLine(Vector relativeOffset)
	{
		Point toPoint = CurCords + relativeOffset;

		Stroke line = GetStrokeLine(CurCords, toPoint, DrawingAttributes);
		CurCords = toPoint;
		_inkCanvas.Strokes.Add(line);

		PenPositionChanged?.Invoke(this, new PositionEventArgs(CurCords-relativeOffset, CurCords));
	}

	/// <summary>
	/// Изменяет местоположение `InkPen` на поле при `UserViewOffsetChanged`
	/// </summary>
	private void MovePen(object? sender, OffsetEventArgs e)
	{
		CurCords += e.Offset;
		PenPositionChanged?.Invoke(this, new PositionEventArgs(CurCords-e.Offset, CurCords));
	}

	
}
