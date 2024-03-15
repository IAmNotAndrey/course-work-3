using ParaPen.Helpers;
using ParaPen.Models;
using ParaPen.Models.CustomGraph;
using ParaPen.Models.CustomGraph.BlockNodes;
using System.Collections.Generic;
using static ParaPen.Helpers.NodeHelper;

namespace ParaPen.Commands;

public class ExecuteAndGoToNextNodesCommand : CommandBase
{
	//private IEnumerable<BlockNode?> _activeNodes;
	private IEnumerable<BlockPenContainer> _blockPenContainers;

	private readonly BlockDiagramGraph _blockDiagram;

	//public ExecuteAndGoToNextNodesCommand(IEnumerable<BlockNode?> activeNodes, BlockDiagramGraph blockDiagram)
	//{
	//	_activeNodes = activeNodes.ToList();
	//	_blockDiagram = blockDiagram;
	//}

	public ExecuteAndGoToNextNodesCommand(IEnumerable<BlockPenContainer> blockPenContainers, BlockDiagramGraph blockDiagram)
	{
		_blockPenContainers = blockPenContainers;
		_blockDiagram = blockDiagram;
	}

	public override void Execute(object? parameter)
	{
		//List<BlockPenContainer> updatedContainers = new();

		foreach (var container in _blockPenContainers)
		{
			BlockNode? node = container.SelectedNode;

			// Если вершина уже null, значит прошли finish
			if (node is null)
			{
				//updatedContainers.Add(container);
				container.SelectedNode = null;
				continue;
			}

			bool branchValue = node.Execute();

			BlockNode? target = ReturnNextNode(node, branchValue, _blockDiagram);
			container.SelectedNode = target;  // Изменяем активный узел в BlockPenContainer

			// Меняем выбранность `Node`
			// bug : так как не происходит изначальная подсветка startNode, то с ней происходит баг подсветки при переходе на другую ноду
			node.ToggleHighlight();
			target.ToggleHighlight();

			//updatedContainers.Add(container);
		}
		//_blockPenContainers = updatedContainers;
	}

	//   public override void Execute(object? parameter)
	//{
	//	List<BlockNode?> newActiveNodes = new();

	//	foreach (var node in _activeNodes)
	//	{
	//		if (node is null)
	//		{
	//			newActiveNodes.Add(node);
	//			continue;
	//		}

	//		bool branchValue = node.Execute();

	//		BlockNode? target = ReturnNextNode(node, branchValue, _blockDiagram);
	//		newActiveNodes.Add(target);

	//		// Меняем выбраннность `Node`
	//		node.ToggleHighlight();
	//		target.ToggleHighlight();
	//	}
	//	_activeNodes = newActiveNodes;
	//}
}
