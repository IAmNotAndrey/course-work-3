using ParaPen.Models.EventArgs;
using ParaPen.Models.Interfaces;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
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
				OnPropertyChanged(nameof(CurCords));
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

	/// <returns>CurCords+offset</returns>
	public Point MoveOffset(Vector offset)
	{
		CurCords += offset;
		return CurCords;
	}

	protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
