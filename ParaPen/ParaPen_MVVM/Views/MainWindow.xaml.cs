using ParaPen.Models.EventArgs;
using ParaPen.ModelViews;
using System.Windows;
using System.Windows.Input;

namespace ParaPen.Views;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
	private bool _isRightMouseButtonDown;
	private Point _cursorPrePos;

	public MainWindow()
	{
		InitializeComponent();

		PreviewMouseWheel += MainWindow_PreviewMouseWheel;

		PreviewMouseMove += MainWindow_PreviewMouseMove;
		PreviewMouseDown += MainWindow_OnMouseEvent;
		PreviewMouseUp += MainWindow_OnMouseEvent;

		DataContext = new InkCanvasVM(inkCanvas);
	}

	private void MainWindow_PreviewMouseMove(object sender, MouseEventArgs e)
	{
		if (!_isRightMouseButtonDown)
		{
			return;
		}
		((InkCanvasVM)DataContext).MoveUserViewCommand.Execute(new PositionEventArgs(_cursorPrePos, e.GetPosition((IInputElement)sender)));
		_cursorPrePos = e.GetPosition((IInputElement)sender);
	}

	private void MainWindow_OnMouseEvent(object sender, MouseButtonEventArgs e)
	{
		if (e.RightButton == MouseButtonState.Pressed && !_isRightMouseButtonDown)
		{
			_isRightMouseButtonDown = true;
			_cursorPrePos = e.GetPosition((IInputElement)sender);
		}
		else if (e.RightButton == MouseButtonState.Released)
		{
			_isRightMouseButtonDown = false;
		}
	}

	private void MainWindow_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
	{
		if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
		{
			if (e.Delta > 0)
			{
				((InkCanvasVM)DataContext).ZoomInCommand.Execute(null);
			}
			else
			{
				((InkCanvasVM)DataContext).ZoomOutCommand.Execute(null);
			}
			e.Handled = true;
		}
	}
}
