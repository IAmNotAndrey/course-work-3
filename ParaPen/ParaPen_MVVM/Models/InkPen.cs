using ParaPen.Models.Interfaces;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Ink;

namespace ParaPen.Models;

public class InkPen : INotifyPropertyChanged, IResetable
{
	private readonly Point _startCords;

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
		_startCords = startCords;
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

	public void Reset() 
	{
		CurCords = _startCords;
	}
}
