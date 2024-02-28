using ParaPen.Models.Interfaces;
using System.Windows;
using System.Windows.Media;

namespace ParaPen.Commands;

public class ZoomOutCommand : CommandBase
{
	private readonly IInkScalerService _scalerService;
	private readonly FrameworkElement _scaling;
	//private readonly IKeyStateService _keyStateService;

	public ZoomOutCommand(FrameworkElement scaling, IInkScalerService scalerService)
	{
		_scalerService = scalerService;
		_scaling = scaling;
		//_keyStateService = keyStateService;
	}

	public override void Execute(object? parameter)
	{
		_scalerService.ChangeScale(false);
		_scaling.LayoutTransform = new ScaleTransform(_scalerService.CurrentScale, _scalerService.CurrentScale);
	}

	//public override bool CanExecute(object? parameter)
	//{
	//	return _keyStateService.IsCtrlPressed && _keyStateService.WheelDelta < 0;
	//}
}
