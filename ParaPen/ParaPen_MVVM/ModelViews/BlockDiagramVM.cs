using ParaPen.Commands;
using ParaPen.Commands.Nodes;
using ParaPen.Models;
using ParaPen.Models.CustomGraph;
using ParaPen.Models.CustomGraph.BlockNodes;
using ParaPen.Models.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using static ParaPen.Models.StaticResources.StaticResources;
using ParaPen.Serializers;
using System.Linq;

namespace ParaPen.ModelViews;

public class BlockDiagramVM : ViewModelBase
{
	private readonly InkCanvas _inkCanvas;
	private readonly IUserViewMover _userViewMover;

	private BlockDiagramGraph _blockDiagram = new();
	public BlockDiagramGraph BlockDiagram
	{
		get => _blockDiagram;
		private set
		{
			_blockDiagram = value;
			OnPropertyChanged(nameof(BlockDiagram));
		}
	}

	public ObservableCollection<BlockPenContainer> BlockPenContainers { get; } = new();


	public ICommand InsertNodeCommand => new InsertNodeCommand(BlockDiagram);

	public ICommand AddBlockPenContainer => new AddBlockPenContainerCommand(BlockPenContainers, BlockDiagram, _userViewMover, _inkCanvas, BLOCK_DIAGRAM_LIMIT);
	public ICommand DeleteBlockPenContainer => new DeleteBlockPenContainerCommand(BlockPenContainers, BlockDiagram);
	//public ICommand ResetBlockPenContainers => ResetBlockPenContainersCommand();

	//public ICommand AddActionNodeCommand => new AddActionNodeCommand(BlockDiagram);


	public ICommand ExecuteAndGoToNextNodesCommand => new ExecuteAndGoToNextNodesCommand(BlockPenContainers, BlockDiagram);

	// todo
	//public ICommand ExecuteAllNodesCommands => new ExecuteAllNodesCommand(_blockPenContainers, BlockDiagram);

	//removeme
	public ICommand TestCommand => new TestCommand();

	public BlockDiagramVM(InkCanvas inkCanvas, IUserViewMover userViewMover)
	{
		_inkCanvas = inkCanvas;
		_userViewMover = userViewMover;

		AddBlockPenContainer.Execute(null);

		
		/*
		////removeme
		//var a = new ActionNode(() => Console.WriteLine(1));
		//var b = new ActionNode(() => Console.WriteLine(2));
		//var c = new ActionNode(() => Console.WriteLine(3));

		//BlockDiagram.AddVertex(a);
		//BlockDiagram.AddVertex(b);
		//BlockDiagram.AddVertex(c);
		//BlockDiagram.AddEdge(new BlockEdge(a, b));
		//BlockDiagram.AddEdge(new BlockEdge(b, c));


		//// fixme : сделать возможным отображение ребра ссылающегося на самого себя
		//BlockDiagram.AddEdge(new BlockEdge(a, a));

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
		//_blockPenContainers.ForEach(b => b.ActiveNode.IsHighlighted = true);
		*/
	}
}