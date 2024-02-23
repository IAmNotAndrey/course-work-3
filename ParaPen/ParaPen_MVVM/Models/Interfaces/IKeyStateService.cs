namespace ParaPen_MVVM.Models.Interfaces;

public interface IKeyStateService
{
	bool IsCtrlPressed { get; set; }
	bool IsRightMouseDown { get; set; }
	int WheelDelta { get; set; }
}
