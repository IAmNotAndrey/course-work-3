using ParaPen.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace ParaPen;

public class InkScaler : IInkScaler
{
	public double ZoomFactor { get; set; } = 1.1;
	public double CurrentScale { get; private set; }

	private readonly InkCanvas _inkCanvas;


	public InkScaler(Window window, InkCanvas inkCanvas, double currentScale=1) 
	{
		_inkCanvas = inkCanvas;
		CurrentScale = currentScale;

		window.PreviewMouseWheel += Window_PreviewMouseWheel;
		window.KeyDown += Window_KeyDown;
	}


	private void ChangeUserViewScale(bool doZoom)
	{
		if (doZoom)
		{
			// Увеличиваем масштаб
			CurrentScale *= ZoomFactor;
		}
		else
		{
			// Уменьшаем масштаб
			CurrentScale /= ZoomFactor;
		}

		_inkCanvas.LayoutTransform = new ScaleTransform(CurrentScale, CurrentScale);
	}

	private void Window_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
	{
		if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
		{
			bool doZoom;
			if (e.Delta > 0)
			{
				doZoom = true;
			}
			else
			{
				doZoom = false;
			}
			ChangeUserViewScale(doZoom);
			e.Handled = true;
		}
	}

	private void Window_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.Key == Key.LeftCtrl || e.Key == Key.RightCtrl)
		{
			e.Handled = true;
		}
	}
}
