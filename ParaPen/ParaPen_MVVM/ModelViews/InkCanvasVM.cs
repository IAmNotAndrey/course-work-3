using ParaPen.Commands;
using ParaPen.Models;
using ParaPen.Models.Interfaces;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace ParaPen.ModelViews;

public class InkCanvasVM : ViewModelBase
{
	private readonly IInkScalerService _inkScalerService;
	private readonly InkCanvas _inkCanvas;
	private readonly IUserViewMover _userViewMover;
	

	public InkCanvasVM(InkCanvas inkCanvas)
	{
		_inkScalerService = new InkScalerService(1.1);
		_inkCanvas = inkCanvas;
		_userViewMover = new UserViewMover();

		_userViewMover.UserViewOffsetChanged += OnUserViewOffsetChanged;
	}

	//public double ZoomFactor => _inkScalerService.ZoomFactor;
	//public double CurrentScale => _inkScalerService.CurrentScale;

	public ICommand ZoomInCommand => new ZoomInCommand(_inkCanvas, _inkScalerService);
	public ICommand ZoomOutCommand => new ZoomOutCommand(_inkCanvas, _inkScalerService);
	public ICommand MoveUserViewCommand => new MoveUserViewCommand(_userViewMover);


	private void OnUserViewOffsetChanged(object? sender, Models.EventArgs.OffsetEventArgs e)
	{
		// Переместить Strokes
		_inkCanvas.Strokes.Transform(new Matrix(1, 0, 0, 1, e.Offset.X, e.Offset.Y), false);
	}
}
