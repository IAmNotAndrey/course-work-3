using ParaPen.EventArgs;
using ParaPen.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ParaPen;

// todo : сделать отображение карандаша + сделать отображение поверх `Strokes` (Canvas.SetZIndex, НО не работает, если находятся в разных `canvas`)
public class InkPenImageDrawer
{
	//private readonly Uri _uri = new("Images/pencil.png", UriKind.Relative);
	//private readonly Image _image = new();

	//removeme
	private readonly Ellipse _ellipse;
	private readonly Canvas _canvas;


	/// <summary>
	/// Отрисовывает изображение карандаша на поле
	/// </summary>
	/// <param name="inkPen"></param>
	/// <param name="grid">Поле, на котором будет размещаться картинка</param>
	public InkPenImageDrawer(IInkPen inkPen, Canvas canvas) 
	{
		//_image.Source = new BitmapImage(_uri);
		//inkCanvas.Children.Add(_image);

		// removeme

		_canvas = canvas;
		_ellipse = new() { Width=20, Height=20, Stroke=new SolidColorBrush(inkPen.DrawingAttributes.Color) };
		canvas.Children.Add(_ellipse);
		Canvas.SetZIndex(_ellipse, 100);

		// ~removeme

		inkPen.PenPositionChanged += InkPen_PenPositionChanged;
		inkPen.OnDispose += InkPen_OnDispose;
	}

	private void InkPen_OnDispose(object? sender, System.EventArgs e)
	{
		// todo : логика удаления элемента на `canvas`
		_canvas.Children.Remove(_ellipse);

		//throw new NotImplementedException();
	}

	private void InkPen_PenPositionChanged(object? sender, PositionEventArgs e)
	{
		// removeme

		Canvas.SetLeft(_ellipse, e.New.X);
		Canvas.SetTop(_ellipse, e.New.Y);

		// ~removeme


		//throw new NotImplementedException();
	}

	// todo
	/// <summary>
	/// Устанавливает цвет фона рисунку
	/// </summary>
	private void SetBackgroundColor()
	{
		throw new NotImplementedException();
	}
}
