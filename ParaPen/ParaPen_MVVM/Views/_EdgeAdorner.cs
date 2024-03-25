using System.Windows.Documents;
using System.Windows.Media;
using System.Windows;

namespace ParaPen.Views;

public class EdgeAdorner : Adorner
{
	public static readonly DependencyProperty IsAdornerVisibleProperty = DependencyProperty.Register(
		"IsAdornerVisible", typeof(bool), typeof(EdgeAdorner), new PropertyMetadata(false));

	public bool IsAdornerVisible
	{
		get { return (bool)GetValue(IsAdornerVisibleProperty); }
		set { SetValue(IsAdornerVisibleProperty, value); }
	}

	public EdgeAdorner(UIElement adornedElement) : base(adornedElement)
	{
		IsHitTestVisible = false;
	}

	protected override void OnRender(DrawingContext drawingContext)
	{
		if (IsAdornerVisible)
		{
			// Рисование вашего кружка
			drawingContext.DrawEllipse(Brushes.Blue, null, new Point(AdornedElement.RenderSize.Width / 2, AdornedElement.RenderSize.Height / 2), 5, 5);
		}
	}
}
