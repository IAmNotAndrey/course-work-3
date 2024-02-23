using ParaPen_MVVM.Models.EventArgs;
using ParaPen_MVVM.Models.Interfaces;
using System;
using System.Windows;

namespace ParaPen_MVVM.Models;

public class UserViewMover : IUserViewMover
{
	public event EventHandler<OffsetEventArgs> UserViewOffsetChanged;

	public double MovementSpeed { get; set; } = 2;
	//private Point cursorPrePos;

	//public UserViewMover(Point cursorPrePos)
	//{
	//	this.cursorPrePos = cursorPrePos;
	//}

	public void MoveUserView(Point cursorPrePos, Point cursorPoint)
	{
		var vector = cursorPoint - cursorPrePos;
		cursorPrePos = cursorPoint;

		double offsetX = vector.X * MovementSpeed;
		double offsetY = vector.Y * MovementSpeed;

		OffsetEventArgs args = new(new Vector(offsetX, offsetY));
		UserViewOffsetChanged?.Invoke(this, args);
	}
}
