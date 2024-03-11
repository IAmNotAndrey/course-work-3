using ParaPen.Models.CustomGraph;
using ParaPen.Models.CustomGraph.BlockNodes;
using ParaPen.Models.Interfaces;
using System.Windows.Controls;
using static ParaPen.Helpers.NodeHelper;

namespace ParaPen.Models;

public class BlockPenContainer
{
	private BlockNode? _activeNode;
	public BlockNode? ActiveNode
	{
		get => _activeNode;
		set
		{
			// FIXME : упростить по возможности
			if (value is InkPenActionNode inkPenActionNode)
			{
				inkPenActionNode.Action = GetActionOutOfPenActions(inkPenActionNode.StepMultiplier, inkPenActionNode.PenAction, inkPenActionNode.Direction, InkPen, InkCanvas);
			}
			_activeNode = value;
		}
	}

	public BlockNode StartNode { get; init; }
	public InkPen InkPen { get; init; }
	public InkCanvas InkCanvas { get; init; }

	public string Label => ToString();
	//public BlockPenContainer() { }


	public BlockPenContainer(IUserViewMover userViewMover)
	{
		userViewMover.UserViewOffsetChanged += OnUserViewOffsetChanged;
	}

	public void Reset()
	{
		ActiveNode = StartNode;
	}

	// FIXME : Для вызова `подпрограммы` стоит сделать HashMap : Action's на данный момент сохраняются только для конкретного `BlockPenContainer`, тогда как должны только указывать действия "обезличенного" карандаша

	///// <summary>
	///// Рисует на inkCanvas линию. Изменяет координаты inkPen на toOffset
	///// </summary>
	//public void DrawLine(Vector toOffset)
	//{
	//	Point startPoint = Pen.CurCords;
	//	// Изменяем координаты и заносим в переменную конечную точку
	//	Point endPoint = Pen.MoveOffset(toOffset);

	//	Stroke line = GetStrokeLine(startPoint, endPoint, Pen.DrawingAttributes);
	//	InkCanvas.Strokes.Add(line);
	//}

	//public void MovePen(Vector toOffset) => Pen.MoveOffset(toOffset);

	private void OnUserViewOffsetChanged(object? sender, EventArgs.OffsetEventArgs e)
	{
		InkPen.CurCords += e.Offset;
	}

	public override string ToString()
	{
		return $"{nameof(BlockPenContainer)} - {InkPen.DrawingAttributes.Color}";
	}
}
