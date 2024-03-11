namespace ParaPen.ModelViews;

public class BlockDiagramUC_VM : ViewModelBase
{
	//private List<BlockNode> _activeNodes = new();
	//private List<BlockPenContainer> _blockPenContainers = new();


	//public ICommand ExecuteAndGoToNextNodesCommand => new ExecuteAndGoToNextNodesCommand(_activeNodes, _blockDiagram);
	//public ICommand ExecuteAllNodesCommands => new ExecuteAllNodesCommand(_activeNodes, _blockDiagram);
	//public ICommand ExecuteAndGoToNextNodesCommand => new ExecuteAndGoToNextNodesCommand(_blockPenContainers.Select(sc => sc.ActiveNode), _blockDiagram);
	//public ICommand ExecuteAllNodesCommands => new ExecuteAllNodesCommand(_blockPenContainers.Select(sc => sc.ActiveNode), _blockDiagram);
	//public ICommand ExecuteAndGoToNextNodesCommand => new ExecuteAndGoToNextNodesCommand(_blockPenContainers, _blockDiagram);
	//public ICommand ExecuteAllNodesCommands => new ExecuteAllNodesCommand(_blockPenContainers.Select(sc => sc.ActiveNode), _blockDiagram);
	
	// todo : сохранять начальные ноды в переменной для сохранения графов


	public BlockDiagramUC_VM()
	{
		//BlockDiagram = new();

		/*
		BlockDiagramGraph blockDiagram = new();


		//removeme
		// 1
		var startNode = new TerminalBlock("Start");
		BlockPenContainer blockPenContainer = new(_userViewMover)
		{
			ActiveNode = startNode,
			InkPen = new InkPen(new Point(0, 0), new DrawingAttributes { Color = Colors.Red, Width = 4, Height = 4 }),
			InkCanvas = _inkCanvas,
			BlockDiagramGraph = blockDiagram,
		};

		bool isBusy() => true;
		List<BlockNode> existingNodes = new()
		{
			//new ActionNode("Action 1", () => blockPenContainer.InkPen.DrawLine(new Vector(100,0), blockPenContainer.InkCanvas)),
			//new ActionNode("Action 2", () => blockPenContainer.InkPen.DrawLine(new Vector(1,100), blockPenContainer.InkCanvas)),
			//new ActionNode("Action 3", () => blockPenContainer.InkPen.DrawLine(new Vector(0,100), blockPenContainer.InkCanvas)),
			new InkPenActionNode("Draw Right", 100, PenActions.Draw, Directions.Right),
			new InkPenActionNode("Draw UpRight", 100, PenActions.Draw, Directions.UpRight),
			new InkPenActionNode("Draw Down", 100, PenActions.Draw, Directions.Down),

			new ConditionNode("Condition 1", isBusy),
			new CountingLoopNode("CountingLoop 1", 1),
			startNode,
			new TerminalBlock("End"),
		};
		//_activeNodes.Add(existingNodes[5]);
		_blockPenContainers.Add(blockPenContainer);

		blockDiagram.AddVertexRange(existingNodes);

		blockDiagram.AddEdge(new BlockEdge(existingNodes[0], existingNodes[3]));
		blockDiagram.AddEdge(new BlockEdge(existingNodes[3], existingNodes[1], false));
		blockDiagram.AddEdge(new BlockEdge(existingNodes[3], existingNodes[4]));
		blockDiagram.AddEdge(new BlockEdge(existingNodes[4], existingNodes[2]));

		blockDiagram.AddEdge(new BlockEdge(existingNodes[2], existingNodes[4]));
		blockDiagram.AddEdge(new BlockEdge(existingNodes[1], existingNodes[6]));
		blockDiagram.AddEdge(new BlockEdge(existingNodes[4], existingNodes[6], false));
		blockDiagram.AddEdge(new BlockEdge(existingNodes[5], existingNodes[0]));


		//removeme
		// 2
		List<BlockNode> existingNodes2 = new()
		{
			new TerminalBlock("Start"),
			new ActionNode("Action 1", () => MessageBox.Show("Executing Action 1")),
			new TerminalBlock("End"),
		};

		//_activeNodes.Add(existingNodes2[0]);
		_blockPenContainers.Add(new BlockPenContainer(_userViewMover)
		{
			ActiveNode = existingNodes2[0],
			InkPen = new InkPen(new Point(0, 0), new DrawingAttributes { Color = Colors.Green, Width = 4, Height = 4 }),
			InkCanvas = _inkCanvas,
			BlockDiagramGraph = blockDiagram
		});

		blockDiagram.AddVertexRange(existingNodes2);

		blockDiagram.AddEdge(new BlockEdge(existingNodes2[0], existingNodes2[1]));
		blockDiagram.AddEdge(new BlockEdge(existingNodes2[1], existingNodes2[2]));


		BlockDiagram = blockDiagram;

		// Устанавливаем для всех активных вершин
		//_activeNodes.ForEach(b => b.IsHighlighted = true);
		_blockPenContainers.ForEach(b => b.ActiveNode.IsHighlighted = true);
		*/
	}

	//	private static BlockEdge GetNewGraphEdge(BlockNode from, BlockNode to)
	//	{
	//		string edgeString = $"{from.Id}-{to.Id} Connected";

	//		BlockEdge newEdge = new(edgeString, null, from, to);

	//		return newEdge;
	//	}
}