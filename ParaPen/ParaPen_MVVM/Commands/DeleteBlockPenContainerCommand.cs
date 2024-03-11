using ParaPen.Models;
using ParaPen.Models.CustomGraph;
using System;
using System.Collections.Generic;

namespace ParaPen.Commands;

public class DeleteBlockPenContainerCommand : CommandBase
{
	private readonly ICollection<BlockPenContainer> _containers;
	private readonly BlockDiagramGraph _blockDiagram;

	public DeleteBlockPenContainerCommand(ICollection<BlockPenContainer> containers, BlockDiagramGraph blockDiagram)
	{
		_containers = containers;
		_blockDiagram = blockDiagram;
	}

	public override void Execute(object? parameter)
	{
		if (parameter is not BlockPenContainer container)
		{
			throw new ArgumentException(null, nameof(parameter));
		}
		//var container = parameter as BlockPenContainer;

		_containers.Remove(container);

		// Удаление вершин из графа
		var connectedNodes = _blockDiagram.GetAllConnectedVertices(container.StartNode);
		_blockDiagram.RemoveVertexRange(connectedNodes);
	}

	// fixme
	//public override bool CanExecute(object? parameter)
	//{
	//	return parameter is not null;
	//}
}
