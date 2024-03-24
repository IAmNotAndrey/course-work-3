using ParaPen.Models.CustomGraph;
using ParaPen.Models.CustomGraph.BlockNodes;
using ParaPen.Models.Interfaces;
using ParaPen.ModelViews;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using static ParaPen.Converters.ColorConverter;

namespace ParaPen.Models;

// FIXME : упростить по возможности
public class BlockPenContainer : IResetable
{
	private BlockNode? _selectedNode;
	//private readonly InkCanvasVM _inkCanvasVM;

	public BlockNode? SelectedNode
	{
		get => _selectedNode;
		set
		{
			// NOTE : изменять при каждом вхождении такой ноды: так как изменяются координаты InkPen
			if (value is InkPenActionNode inkPenActionNode)
			{
				inkPenActionNode.Action = inkPenActionNode.ToActionNode(InkPen, InkCanvas).Action;
			}
			else if (value is InkConditionNode inkConditionNode)
			{
				// BUG условие работает неправильно, если до его вызова перемещать UserView
				inkConditionNode.Condition = inkConditionNode.ToConditionNode(InkPen, InkCanvas).Condition;
			}

			// Изменяем подсветку вершины
			if (_selectedNode != null)
			{
				_selectedNode.IsHighlighted = false;
			}
			if (value != null)
			{
				value.IsHighlighted = true;
			}
			_selectedNode = value;
		}
	}

	// note: было init. Может быть опасно
	public BlockNode StartNode { get; set; }
	public InkPen InkPen { get; init; }
	public InkCanvas InkCanvas { get; init; }
	public string Label => ToString();

	// note могу вызывать ошибки, пока не протестил! может не стоит использовать?
	public BlockDiagramGraph BlockDiagramGraph { get; init; }



	public BlockPenContainer() { }


	public BlockPenContainer(IUserViewMover userViewMover)
	{
		userViewMover.UserViewOffsetChanged += OnUserViewOffsetChanged;
		//_inkCanvasVM = inkCanvasVM;
	}

	public void Reset()
	{
		// Находим все вершины, которые реализуют интерфейс IResetable
		IEnumerable<IResetable> resetableNodes = BlockDiagramGraph.GetAllConnectedVertices(StartNode).OfType<IResetable>();
		// Переустанавливаем все найденные вершины
		foreach (var rn in resetableNodes) rn.Reset();

		//// Реальные начальные координаты у карандаша могли быть изменены при перемещении UserView, поэтому выполняем
		//InkPen.CurCords += _inkCanvasVM.UserViewOffset;
		InkPen.Reset();

		SelectedNode = StartNode;
	}

	private void OnUserViewOffsetChanged(object? sender, EventArgs.OffsetEventArgs e)
	{
		InkPen.CurCords += e.Offset;
		InkPen.StartCords += e.Offset;
	}

	public override string ToString()
	{
		// fixme не отображается название цвета
		//return $"Container - {InkPen.DrawingAttributes.Color.ToDrawingColor().Name}";
		return $"Container - {InkPen.DrawingAttributes.Color.ToDrawingColor().Name}";
	}
}
