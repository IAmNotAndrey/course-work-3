namespace ParaPen.Models.Interfaces;

public interface IKeyStateService
{
	bool IsCtrlPressed { get; set; }
	bool IsRightMouseDown { get; set; }
	int WheelDelta { get; set; }
}
