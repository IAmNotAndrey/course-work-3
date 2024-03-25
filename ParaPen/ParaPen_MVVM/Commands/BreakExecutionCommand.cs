using ParaPen.Models;
using ParaPen.Models.CustomGraph;
using ParaPen.ModelViews;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace ParaPen.Commands;

public class BreakExecutionCommand : CommandBase
{
	private ObservableCollection<BlockPenContainer> _blockPenContainers;
	private InkCanvas _inkCanvas;
	private readonly BlockDiagramVM _vm;

	public BreakExecutionCommand(ObservableCollection<BlockPenContainer> blockPenContainers, InkCanvas inkCanvas, BlockDiagramVM vm)
	{
		_blockPenContainers = blockPenContainers;
		_inkCanvas = inkCanvas;
		_vm = vm;
	}

	public override void Execute(object? parameter)
	{
		foreach (var bpContainer in _blockPenContainers)
		{
			bpContainer.Reset();
			//bpContainer.StartNode.IsHighlighted = true;
		}
		_inkCanvas.Strokes.Clear();
		_vm.Tracebacker.Reset();
	}
}
