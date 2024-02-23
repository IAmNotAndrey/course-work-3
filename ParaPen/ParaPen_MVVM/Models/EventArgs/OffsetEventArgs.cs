using System.Windows;

namespace ParaPen_MVVM.Models.EventArgs;

public class OffsetEventArgs
{
	public Vector Offset { get; }

	public OffsetEventArgs(Vector offset)
	{
		Offset = offset;
	}
}
