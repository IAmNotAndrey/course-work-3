using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ParaPen.EventArgs;

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
