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
				curCords = value;
				OnPropertyChanged(nameof(CurCords));
				//OnPropertyChanged(nameof(CurCords.X));
				//OnPropertyChanged(nameof(CurCords.Y));
			}
		}
	}


	public DrawingAttributes DrawingAttributes { get; }

    public InkPen(Point startCords, DrawingAttributes drawingAttributes)
    {
        CurCords = startCords;
        DrawingAttributes = drawingAttributes;
    }

	/// <returns><see cref="CurCords"/> <see langword="+"/> <paramref name="offset"/></returns>
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
