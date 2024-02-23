using ParaPen.EventArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Diagnostics.CodeAnalysis;
using ParaPen.Models.Interfaces;

namespace ParaPen;

public class UserViewMover : IUserViewMover
{
	public event EventHandler<OffsetEventArgs> UserViewOffsetChanged;

	public double MovementSpeed { get; set; } = 2;

	private bool _isRightMouseButtonDown;
	private Point _cursorPrevPos;


	public UserViewMover(Window window)
	{
		window.PreviewMouseMove += Window_PreviewMouseMove;
		window.PreviewMouseDown += Window_OnMouseEvent;
		window.PreviewMouseUp += Window_OnMouseEvent;
	}


	private void MoveUserView(Point cursorPoint)
	{
		if (!_isRightMouseButtonDown)
		{
			return;
		}
		var vector = cursorPoint - _cursorPrevPos;
		_cursorPrevPos = cursorPoint;

		double offsetX = vector.X * MovementSpeed;
		double offsetY = vector.Y * MovementSpeed;

		OffsetEventArgs args = new(new Vector(offsetX, offsetY));
		UserViewOffsetChanged?.Invoke(this, args);
	}

	private void Window_PreviewMouseMove(object sender, MouseEventArgs e)
	{
		MoveUserView(e.GetPosition((IInputElement)sender));
	}

	private void Window_OnMouseEvent(object sender, MouseButtonEventArgs e)
	{
		if (e.RightButton == System.Windows.Input.MouseButtonState.Pressed && !_isRightMouseButtonDown)
		{
			_isRightMouseButtonDown = true;
			_cursorPrevPos = e.GetPosition((IInputElement)sender);
		}
		else if (e.RightButton == MouseButtonState.Released)
		{
			_isRightMouseButtonDown = false;
		}
	}
}
