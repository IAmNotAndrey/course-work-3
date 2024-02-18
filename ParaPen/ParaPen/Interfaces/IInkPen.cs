using ParaPen.EventArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Ink;

namespace ParaPen.Interfaces;

public interface IInkPen : IDisposable
{
	event EventHandler<PositionEventArgs> PenPositionChanged;
	event EventHandler OnDispose;

	System.Windows.Point CurCords { get; set; }
	DrawingAttributes DrawingAttributes { get; init; }

}
