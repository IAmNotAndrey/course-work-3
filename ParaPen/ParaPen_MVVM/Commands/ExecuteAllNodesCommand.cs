using ParaPen.Models.CustomGraph;
using System.Collections.Generic;
using System.Linq;

namespace ParaPen.Commands;

public class ExecuteAllNodesCommand : CommandBase
{
	private IEnumerable<BlockNode?> _activeNodes;
	private readonly BlockDiagramGraph _blockDiagram;

	public ExecuteAllNodesCommand(IEnumerable<BlockNode?> activeNodes, BlockDiagramGraph blockDiagram)
    {
		_activeNodes = activeNodes;
		_blockDiagram = blockDiagram;
	}

    public override void Execute(object? parameter)
	{
		while (_activeNodes.All(n => n is not null))
		{
		// FIXME : не происходит обновление _actionNodes
			IEnumerable<BlockNode?> newActiveNodes = _activeNodes.ToList();
			ExecuteAndGoToNextNodesCommand command = new(newActiveNodes, _blockDiagram);
			command.Execute(null);
			_activeNodes = newActiveNodes;
		}
	}
}
