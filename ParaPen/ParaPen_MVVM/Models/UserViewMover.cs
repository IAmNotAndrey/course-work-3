using ParaPen.Models.EventArgs;
using ParaPen.Models.Interfaces;
using System;
using System.Windows;

namespace ParaPen.Models;

public class UserViewMover : IUserViewMover
{
	public event EventHandler<OffsetEventArgs> UserViewOffsetChanged;

	public double MovementSpeed { get; set; }

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
