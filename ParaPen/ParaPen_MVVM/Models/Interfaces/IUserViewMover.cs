using ParaPen.Models.EventArgs;
using System;
using System.Windows;

namespace ParaPen.Models.Interfaces;

public interface IUserViewMover
{
    event EventHandler<OffsetEventArgs> UserViewOffsetChanged;
    
    double MovementSpeed { get; set; }

	void MoveUserView(Point cursorPrePos, Point cursorPoint);
}
