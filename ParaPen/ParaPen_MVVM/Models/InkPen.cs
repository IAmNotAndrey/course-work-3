using ParaPen.Models.EventArgs;
using ParaPen.Models.Interfaces;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Ink;

namespace ParaPen.Models;

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
    //public InkPenMode Mode { get; }

    public InkPen(Point startCords, DrawingAttributes drawingAttributes)
    {
        CurCords = startCords;
        DrawingAttributes = drawingAttributes;
        //Mode = mode;
    }
}
