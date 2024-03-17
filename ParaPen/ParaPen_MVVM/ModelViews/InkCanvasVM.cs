using ParaPen.Commands;
using ParaPen.Models;
using ParaPen.Models.Interfaces;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using static ParaPen.Models.StaticResources.AppConfig;

namespace ParaPen.ModelViews;

public class InkCanvasVM : ViewModelBase
{
	private readonly IInkScalerService _inkScalerService;
	private readonly InkCanvas _inkCanvas;

	public IUserViewMover UserViewMover { get; init; }
	public Vector UserViewOffset { get; private set; } = new(0, 0);


	//fixme это ссылка из BlockDiagramVM! Не надо так делать
	public ObservableCollection<BlockPenContainer> BlockPenContainers { get; set; }


	public ICommand ZoomInCommand => new ZoomInCommand(_inkCanvas, _inkScalerService);
	public ICommand ZoomOutCommand => new ZoomOutCommand(_inkCanvas, _inkScalerService);
	public ICommand MoveUserViewCommand => new MoveUserViewCommand(UserViewMover);


	public InkCanvasVM(InkCanvas inkCanvas)
	{
		_inkScalerService = new InkScalerService(ZOOM_FACTOR);
		_inkCanvas = inkCanvas;
		UserViewMover = new UserViewMover() { MovementSpeed = USER_VIEW_SPEED } ;

		UserViewMover.UserViewOffsetChanged += OnUserViewOffsetChanged;
	}


	private void OnUserViewOffsetChanged(object? sender, Models.EventArgs.OffsetEventArgs e)
	{
		// Перемещаем Strokes
		_inkCanvas.Strokes.Transform(new Matrix(1, 0, 0, 1, e.Offset.X, e.Offset.Y), false);
		UserViewOffset += e.Offset;
	}
}
