using ParaPen.Models.EventArgs;
using ParaPen_MVVM.Models.Interfaces;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Ink;

namespace ParaPen_MVVM.Models;

public class InkPen : INotifyPropertyChanged
{
    //public event EventHandler<PositionEventArgs> PenPositionChanged;
	public event PropertyChangedEventHandler? PropertyChanged;

	private Point curCords;
	public Point CurCords
	{
		get => curCords;
		set
		{
			if (curCords != value)
			{
				//PenPositionChanged?.Invoke(this, new PositionEventArgs(curCords, value));
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurCords)));
				curCords = value;
			}
		}
	}

	public DrawingAttributes DrawingAttributes { get; }
    public InkPenMode Mode { get; }

    public InkPen(Point startCords, DrawingAttributes drawingAttributes, InkPenMode mode=InkPenMode.Move)
    {
        CurCords = startCords;
        DrawingAttributes = drawingAttributes;
        Mode = mode;
    }
}
