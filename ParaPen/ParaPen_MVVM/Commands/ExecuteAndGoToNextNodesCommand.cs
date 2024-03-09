using ParaPen.Helpers;
using ParaPen.Models.CustomGraph;
using ParaPen.Models.CustomGraph.BlockNodes;
using ParaPen.ModelViews;
using System.Collections.Generic;
using System.Linq;
using static ParaPen.Helpers.NodeHelper;

namespace ParaPen.Commands;

public class ExecuteAndGoToNextNodesCommand : CommandBase
{
	private IEnumerable<BlockNode?> _activeNodes;
	private readonly BlockDiagramGraph _blockDiagram;

	public ExecuteAndGoToNextNodesCommand(IEnumerable<BlockNode?> activeNodes, BlockDiagramGraph blockDiagram)
	{
		_activeNodes = activeNodes;
		_blockDiagram = blockDiagram;
	}

	public override void Execute(object? parameter)
	{
		List<BlockNode?> newActiveNodes = new();

		foreach (var node in _activeNodes)
		{
			if (node is null)
			{
				newActiveNodes.Add(node);
				continue;
			}

			bool branchValue = node.Execute();

			BlockNode? target = ReturnNextNode(node, branchValue, _blockDiagram);
			newActiveNodes.Add(target);

			// Меняем выбраннность `Node`
			node.ToggleHighlight();
			target.ToggleHighlight();
		}
		_activeNodes = newActiveNodes;
	}
}
