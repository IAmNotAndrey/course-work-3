using ParaPen.Commands;
using ParaPen.Commands.Nodes;
using ParaPen.Commands.Serialization;
using ParaPen.Models;
using ParaPen.Models.CustomGraph;
using ParaPen.Models.Interfaces;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using static ParaPen.Models.StaticResources.StaticResources;

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


	#region Commands

	public ICommand InsertNodeCommand => new InsertNodeCommand(BlockDiagram, BlockPenContainers);

	public ICommand AddBlockPenContainer => new AddBlockPenContainerCommand(BlockPenContainers, BlockDiagram, _userViewMover, _inkCanvas, BLOCK_DIAGRAM_LIMIT);
	public ICommand DeleteBlockPenContainer => new DeleteBlockPenContainerCommand(BlockPenContainers, BlockDiagram);

	public ICommand SerializeEdges => new SerializeEdgesCommand(BlockDiagram);

	//todo
	//public ICommand ResetBlockPenContainers => ResetBlockPenContainersCommand();

	public ICommand ExecuteAndGoToNextNodesCommand => new ExecuteAndGoToNextNodesCommand(BlockPenContainers, BlockDiagram);

	// todo
	//public ICommand ExecuteAllNodesCommands => new ExecuteAllNodesCommand(_blockPenContainers, BlockDiagram);


	#endregion

	public BlockDiagramVM(InkCanvas inkCanvas, IUserViewMover userViewMover)
	{
		_inkCanvas = inkCanvas;
		_userViewMover = userViewMover;

		AddBlockPenContainer.Execute(null);
	}
}