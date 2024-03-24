using ParaPen.Models.CustomGraph;
using ParaPen.Models.CustomGraph.BlockNodes;
using ParaPen.Models.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using static ParaPen.Converters.ColorConverter;

namespace ParaPen.Models;

// FIXME : упростить по возможности
public class BlockPenContainer : IResetable
{
	private BlockNode? _selectedNode;
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
				inkConditionNode.Condition = inkConditionNode.ToConditionNode(InkPen, InkCanvas).Condition;
			}
			_selectedNode = value;
		}
	}

	// note: было init. Может быть опасно
	public BlockNode StartNode { get; set; }
	public InkPen InkPen { get; init; }
	public InkCanvas InkCanvas { get; init; }

	// note могу вызывать ошибки, пока не протестил! может не стоит использовать?
	public BlockDiagramGraph BlockDiagramGraph { get; init; }

	public string Label => ToString();


	public BlockPenContainer() { }


	public BlockPenContainer(IUserViewMover userViewMover)
	{
		userViewMover.UserViewOffsetChanged += OnUserViewOffsetChanged;
	}

	public void Reset()
	{
		SelectedNode = StartNode;
		// bug при смещении и остановке выполнения устанавливаются неправильные координаты
		InkPen.Reset();

		// Находим все вершины, которые реализуют интерфейс IResetable
		IEnumerable<IResetable> resetableNodes = BlockDiagramGraph.GetAllConnectedVertices(StartNode).OfType<IResetable>();
		// Переустанавливаем все найденные вершины
		foreach (var rn in resetableNodes) rn.Reset();
	}

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
}
