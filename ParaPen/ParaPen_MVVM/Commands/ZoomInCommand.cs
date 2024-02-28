using ParaPen.Models.Interfaces;
using System.Windows;
using System.Windows.Media;

namespace ParaPen.Commands;

public class ZoomInCommand : CommandBase
{
	private readonly IInkScalerService _scalerService;
	private readonly FrameworkElement _scaling;
	//private readonly IKeyStateService _keyStateService;

	public ZoomInCommand(FrameworkElement scaling, IInkScalerService scalerService)
	{
		_scalerService = scalerService;
		_scaling = scaling;
		//_keyStateService = keyStateService;
	}

	public override void Execute(object? parameter)
	{
		_scalerService.ChangeScale(true);
		_scaling.LayoutTransform = new ScaleTransform(_scalerService.CurrentScale, _scalerService.CurrentScale);
	}

	//public override bool CanExecute(object? parameter)
	//{
	//	return _keyStateService.IsCtrlPressed && _keyStateService.WheelDelta > 0;
	//}
}
