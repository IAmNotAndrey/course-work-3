using ParaPen_MVVM.Models.Interfaces;

namespace ParaPen_MVVM.Models;

public class KeyStateService : IKeyStateService
{
	public bool IsCtrlPressed { get; set; }
	public bool IsRightMouseDown { get; set; }
	public int WheelDelta { get; set; }
}
