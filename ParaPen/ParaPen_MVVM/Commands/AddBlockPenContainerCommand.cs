using ParaPen.Models;
using ParaPen.Models.CustomGraph;
using ParaPen.Models.CustomGraph.BlockNodes;
using ParaPen.Models.Interfaces;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Ink;
using System.Windows.Media;

namespace ParaPen.Commands;

public class AddBlockPenContainerCommand : CommandBase
{
	private readonly ICollection<BlockPenContainer> _blockPenContainers;
	private readonly BlockDiagramGraph _blockDiagram;
	private readonly IUserViewMover _userViewMover;
	private readonly InkCanvas _inkCanvas;
	private readonly uint _limit;

	public AddBlockPenContainerCommand(ICollection<BlockPenContainer> blockPenContainers, BlockDiagramGraph blockDiagram, IUserViewMover userViewMover, InkCanvas inkCanvas, uint limit)
	{
		_blockPenContainers = blockPenContainers;
		_blockDiagram = blockDiagram;
		_userViewMover = userViewMover;
		_inkCanvas = inkCanvas;
		_limit = limit;
	}

	public override void Execute(object? parameter)
	{
		TerminalNode startNode = new("Start");
		TerminalNode endNode = new("End");
		BlockEdge edge = new(startNode, endNode);

		_blockPenContainers.Add(new BlockPenContainer(_userViewMover)
		{
			StartNode = startNode,
			InkCanvas = _inkCanvas,
			SelectedNode = startNode,
			InkPen = new InkPen(new Point(0, 0), new DrawingAttributes { Color = Colors.Green, Width = 4, Height = 4 }), // fixme
		});

		_blockDiagram.AddVertex(startNode);
		_blockDiagram.AddVertex(endNode);
		_blockDiagram.AddEdge(edge);
	}

	public override bool CanExecute(object? parameter)
	{
		return _blockPenContainers.Count < _limit;
	}
}
