using System.Windows;

namespace ParaPen.Models.EventArgs;

public class PositionEventArgs
{
	public Point Old { get; }
	public Point New { get; }

	public PositionEventArgs(Point old, Point @new)
	{
		Old = old;
		New = @new;
	}
}
