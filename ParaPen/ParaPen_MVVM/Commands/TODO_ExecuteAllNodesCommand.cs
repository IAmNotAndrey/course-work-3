using ParaPen.Models.CustomGraph;
using ParaPen.Models.CustomGraph.BlockNodes;
using System;
using System.Collections.Generic;

namespace ParaPen.Commands;

// todo
public class TODO_ExecuteAllNodesCommand : CommandBase
{
	private IEnumerable<BlockNode?> _activeNodes;
	private readonly BlockDiagramGraph _blockDiagram;

	public TODO_ExecuteAllNodesCommand(IEnumerable<BlockNode?> activeNodes, BlockDiagramGraph blockDiagram)
    {
		_activeNodes = activeNodes;
		_blockDiagram = blockDiagram;
	}

	public override void Execute(object? parameter)
	{
		//while (_activeNodes.All(n => n is not null))
		//{
		//	// FIXME : не происходит обновление _actionNodes
		//	IEnumerable<BlockNode?> newActiveNodes = _activeNodes.ToList();
		//	ExecuteAndGoToNextNodesCommand command = new(newActiveNodes, _blockDiagram);
		//	command.Execute(null);
		//	_activeNodes = newActiveNodes;
		//}
		throw new NotImplementedException();
	}
}
