using ParaPen.Models.CustomGraph.BlockNodes;
using ParaPen.Models.Interfaces;
using System;
using System.Windows.Controls;
using static ParaPen.Converters.ColorConverter;

namespace ParaPen.Models;

public class BlockPenContainer
{
	private readonly IUserViewMover _userViewMover;

	private BlockNode? _selectedNode;
	public BlockNode? SelectedNode
	{
		get => _selectedNode;
		set
		{
			// FIXME : упростить по возможности

			// NOTE : изменять при каждом вхождении такой ноды: так как изменяются координаты InkPen
			if (value is InkPenActionNode inkPenActionNode)
			{
				inkPenActionNode.Action = inkPenActionNode.ToActionNode(InkPen, InkCanvas).Action;
			}
			else if (value is InkConditionNode inkConditionNode)
			{
				inkConditionNode.Condition = inkConditionNode.ToConditionNode(InkPen, InkCanvas).Condition;
			}
			_selectedNode = value;
		}
	}

	// note: было init. Может быть опасно
	public BlockNode StartNode { get; set; }
	public InkPen InkPen { get; init; }
	public InkCanvas InkCanvas { get; init; }

	public string Label => ToString();


	public BlockPenContainer() { }


	public BlockPenContainer(IUserViewMover userViewMover)
	{
		_userViewMover = userViewMover;

		userViewMover.UserViewOffsetChanged += OnUserViewOffsetChanged;
	}

	public void Reset()
	{
		SelectedNode = StartNode;
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
		// fixme не отображается название цвета
		//return $"Container - {InkPen.DrawingAttributes.Color.ToDrawingColor().Name}";
		return $"Container - {InkPen.DrawingAttributes.Color.ToDrawingColor().Name}";
	}

	//public object Clone()
	//{
	//	return new BlockPenContainer(_userViewMover)
	//	{
	//		InkCanvas = InkCanvas,
	//		InkPen = InkPen,
	//		SelectedNode = SelectedNode,
	//		StartNode = StartNode
	//	};
	//}
}
