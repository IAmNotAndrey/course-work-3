using ParaPen.Models;
using ParaPen.Models.CustomGraph;
using ParaPen.ModelViews;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace ParaPen.Commands;

public class ExecuteAllNodesCommand : CommandBase
{
	private readonly ExecuteAndGoToNextNodesCommand _command;
	private readonly TimeSpan _actionDelayTime;
	private ObservableCollection<BlockPenContainer> _blockPenContainers;

	public ExecuteAllNodesCommand(TimeSpan actionDelayTime, ObservableCollection<BlockPenContainer> blockPenContainers, BlockDiagramGraph blockDiagram, BlockDiagramVM vm)
	{
		_actionDelayTime = actionDelayTime;
		_blockPenContainers = blockPenContainers;
		_command = new ExecuteAndGoToNextNodesCommand(blockPenContainers, blockDiagram, vm);
	}

	public override async void Execute(object? parameter)
	{
		// fixme для завершения выполнения команды выбрать другой способ
		while (!_blockPenContainers.All(c => c.SelectedNode is null))
		{
			_command.Execute(null);
			await Task.Delay(_actionDelayTime);
		}
	}
}
