using ParaPen.EventArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Ink;
using System.Windows.Media.Imaging;
using System.Diagnostics.CodeAnalysis;
using ParaPen.Models.Interfaces;

namespace ParaPen;

public class InkDrawer
{
	private readonly InkCanvas _inkCanvas;


	public InkDrawer(InkCanvas inkCanvas, IUserViewMover userViewMover)
	{
		_inkCanvas = inkCanvas;

		userViewMover.UserViewOffsetChanged += MoveStrokes;
	}


	/// <summary>
	/// Перемещает `Strokes` на `e.Offset`
	/// </summary>
	private void MoveStrokes(object? sender, OffsetEventArgs e)
	{
		// Переместить Strokes
		_inkCanvas.Strokes.Transform(new Matrix(1, 0, 0, 1, e.Offset.X, e.Offset.Y), false);
	}
}
