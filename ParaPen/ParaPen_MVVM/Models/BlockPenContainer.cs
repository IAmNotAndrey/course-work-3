using ParaPen.Models.CustomGraph;
using ParaPen.Models.Interfaces;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Ink;
using static ParaPen.Helpers.InkCanvasMethods;

namespace ParaPen.Models;

public class BlockPenContainer
{
	public BlockNode ActiveNode { get; set; } = null!;
	public InkPen Pen { get; init; } = null!;
	public InkCanvas InkCanvas { get; init; } = null!;

    //public BlockPenContainer() { }

    public BlockPenContainer(IUserViewMover userViewMover)
    {
		userViewMover.UserViewOffsetChanged += OnUserViewOffsetChanged;
    }

	/// <summary>
	/// Рисует на inkCanvas линию. Изменяет координаты inkPen на toOffset
	/// </summary>
	public void DrawLine(Vector toOffset)
	{
		Point startPoint = Pen.CurCords;
		// Изменяем координаты и заносим в переменную
		Point endPoint = Pen.MoveOffset(toOffset);

		Stroke line = GetStrokeLine(startPoint, endPoint, Pen.DrawingAttributes);
		InkCanvas.Strokes.Add(line);
	}

	public void MovePen(Vector toOffset) => Pen.MoveOffset(toOffset);

	private void OnUserViewOffsetChanged(object? sender, EventArgs.OffsetEventArgs e)
	{
		Pen.CurCords += e.Offset;
	}
}
