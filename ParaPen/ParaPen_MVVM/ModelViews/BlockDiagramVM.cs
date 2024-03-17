using ParaPen.Commands;
using ParaPen.Commands.Nodes;
using ParaPen.Commands.Serialization;
using ParaPen.Models;
using ParaPen.Models.CustomGraph;
using ParaPen.Models.Interfaces;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using static ParaPen.Models.StaticResources.AppConfigs;

namespace ParaPen.ModelViews;

public class BlockDiagramVM : ViewModelBase
{
	private readonly InkCanvasVM _inkCanvasVM;
	private readonly InkCanvas _inkCanvas;
	private IUserViewMover UserViewMover => _inkCanvasVM.UserViewMover;


	private readonly Vector _inkCanvasWindowViewOffset;

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

	public ICommand AddBlockPenContainer => new AddBlockPenContainerCommand(BlockPenContainers, BlockDiagram, UserViewMover, _inkCanvas, BLOCK_DIAGRAM_LIMIT, _inkCanvasVM);
	public ICommand DeleteBlockPenContainer => new DeleteBlockPenContainerCommand(BlockPenContainers, BlockDiagram);

	public ICommand SerializeEdges => new SerializeEdgesCommand(BlockDiagram);

	//todo
	//public ICommand ResetBlockPenContainers => ResetBlockPenContainersCommand();

	public ICommand ExecuteAndGoToNextNodesCommand => new ExecuteAndGoToNextNodesCommand(BlockPenContainers, BlockDiagram);

	// todo
	//public ICommand ExecuteAllNodesCommands => new ExecuteAllNodesCommand(_blockPenContainers, BlockDiagram);


	#endregion

	//public BlockDiagramVM(InkCanvas inkCanvas, IUserViewMover userViewMover, ref Vector inkCanvasWindowViewOffset)
	//{
	//	_inkCanvas = inkCanvas;
	//	_userViewMover = userViewMover;

	//	_inkCanvasWindowViewOffset = inkCanvasWindowViewOffset;

	//	AddBlockPenContainer.Execute(null);
	//}

	public BlockDiagramVM(InkCanvasVM inkCanvasVM, InkCanvas inkCanvas)
	{
		_inkCanvasVM = inkCanvasVM;
		_inkCanvas = inkCanvas;

		AddBlockPenContainer.Execute(null);
	}
}