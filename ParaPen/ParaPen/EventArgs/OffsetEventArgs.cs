using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ParaPen.EventArgs;

public class OffsetEventArgs
{
	public System.Windows.Vector Offset { get; }

	public OffsetEventArgs(Vector offset)
	{
		Offset = offset;
	}
}
