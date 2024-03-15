using ParaPen.Models.CustomGraph;
using ParaPen.Models.CustomGraph.BlockNodes;
using System;

namespace ParaPen.Commands.Nodes;

// removeme
public class AddActionNodeCommand : CommandBase
{
	private readonly BlockDiagramGraph _blockDiagramGraph;

	public AddActionNodeCommand(BlockDiagramGraph blockDiagramGraph)
    {
		_blockDiagramGraph = blockDiagramGraph;
	}

	/// <param name="parameter">{node, edge}</param>
    public override void Execute(object? parameter)
	{
		if (parameter is not object[] values || values.Length != 2)
		{
			throw new ArgumentException(null, nameof(parameter));
		}

		var node = (InkPenActionNode)values[0];
		var edge = (BlockEdge)values[1];

		var s = edge.Source;
		var t = edge.Target;

		_blockDiagramGraph.RemoveEdge(edge);

		_blockDiagramGraph.AddVertex(node);
		_blockDiagramGraph.AddEdge(new BlockEdge(s, node));
		_blockDiagramGraph.AddEdge(new BlockEdge(node, t));
	}
}
