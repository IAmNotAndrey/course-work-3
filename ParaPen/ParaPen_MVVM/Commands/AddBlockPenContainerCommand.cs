using ParaPen.Helpers;
using ParaPen.Models;
using ParaPen.Models.CustomGraph;
using ParaPen.Models.CustomGraph.BlockNodes;
using ParaPen.Models.Interfaces;
using ParaPen.ModelViews;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Ink;
using System.Windows.Media;
using static ParaPen.Models.StaticResources.AppConfigs;

namespace ParaPen.Commands;

public class AddBlockPenContainerCommand : CommandBase
{
	private readonly ICollection<BlockPenContainer> _blockPenContainers;
	private readonly BlockDiagramGraph _blockDiagram;
	private readonly IUserViewMover _userViewMover;
	private readonly InkCanvas _inkCanvas;
	private readonly uint _limit;
	private readonly InkCanvasVM _inkCanvasVM;

	private readonly UniqueColorService _colorService;

	public AddBlockPenContainerCommand(
		ICollection<BlockPenContainer> blockPenContainers, 
		BlockDiagramGraph blockDiagram, 
		IUserViewMover userViewMover, 
		InkCanvas inkCanvas, 
		uint limit,
		InkCanvasVM inkCanvasVM // Используем для задания корректной начальной координаты точки путём получения свойства 
	)
	{
		_blockPenContainers = blockPenContainers;
		_blockDiagram = blockDiagram;
		_userViewMover = userViewMover;
		_inkCanvas = inkCanvas;
		_limit = limit;
		_inkCanvasVM = inkCanvasVM;

		_colorService = new(CONTRAST_THRESHOLD);
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
			InkPen = new InkPen(
				(Point)(PEN_START_CORDS + _inkCanvasVM.UserViewOffset), // fixme Упростить по возможности. Используем для задания корректной начальной координаты (до создания возможны сдвиги, поэтому их учитываем)
				new DrawingAttributes { 
					Color = _colorService.GetUniqueColor(), 
					Width = PEN_STROKE_WIDTH, 
					Height = PEN_STROKE_HEIGHT 
			}),
			BlockDiagramGraph = _blockDiagram,
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
