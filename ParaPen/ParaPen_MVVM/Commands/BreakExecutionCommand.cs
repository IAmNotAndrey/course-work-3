using ParaPen.Models;
using ParaPen.Models.CustomGraph;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace ParaPen.Commands;

public class BreakExecutionCommand : CommandBase
{
	private ObservableCollection<BlockPenContainer> _blockPenContainers;
	private InkCanvas _inkCanvas;

	public BreakExecutionCommand(ObservableCollection<BlockPenContainer> blockPenContainers, InkCanvas inkCanvas)
	{
		_blockPenContainers = blockPenContainers;
		_inkCanvas = inkCanvas;
	}

	public override void Execute(object? parameter)
	{
		foreach (var bpContainer in _blockPenContainers)
		{
			bpContainer.Reset();
			//bpContainer.StartNode.IsHighlighted = true;
		}
		_inkCanvas.Strokes.Clear();
	}
}
