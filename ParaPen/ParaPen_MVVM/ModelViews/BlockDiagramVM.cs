using ParaPen.Models.CustomGraph;
using QuickGraph;
using System;
using System.Collections.Generic;

namespace ParaPen.ModelViews;

public class BlockDiagramVM : ViewModelBase
{
	private BlockDiagramGraph _blockDiagram;
	public BlockDiagramGraph BlockDiagram
	{
		get => _blockDiagram;
		private set 
		{
			_blockDiagram = value;
			OnPropertyChanged(nameof(BlockDiagram));
		}
	}

	public BlockDiagramVM()
	{
		BlockDiagramGraph blockDiagram = new();

		Func<bool> func = () => true;
		List<BlockNode> existingNodes = new()
		{
			new ActionNode("0", "Action 1", () => Console.WriteLine("Executing Action 1")),
			new ActionNode("1", "Action 2", () => Console.WriteLine("Executing Action 1")),
			new ActionNode("2", "Action 3", () => Console.WriteLine("Executing Action 3")),
			new ConditionNode("3", "Condition 1", func),
			new CountingLoopNode("4", "CountingLoop 1", 5),
		};
		blockDiagram.AddVertexRange(existingNodes);

		blockDiagram.AddEdge(new BlockEdge("0", null, existingNodes[0], existingNodes[3]));
		blockDiagram.AddEdge(new BlockEdge("1", "No", existingNodes[3], existingNodes[1]));
		blockDiagram.AddEdge(new BlockEdge("2", "Yes", existingNodes[3], existingNodes[4]));
		blockDiagram.AddEdge(new BlockEdge("3", "Yes", existingNodes[4], existingNodes[2]));

		BlockDiagram = blockDiagram;
	}


	private static BlockEdge GetNewGraphEdge(BlockNode from, BlockNode to)
	{
		string edgeString = $"{from.Id}-{to.Id} Connected";

		BlockEdge newEdge = new(edgeString, null, from, to);

		return newEdge;
	}
}