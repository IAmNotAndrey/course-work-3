using ParaPen.Models.Interfaces;
using System.ComponentModel;

namespace ParaPen.Models;

public class InkScalerService : IInkScalerService
{
	public event PropertyChangedEventHandler PropertyChanged;

	public double ZoomFactor { get; }
	public double CurrentScale { get; private set; }

	public InkScalerService(double zoomFactor, double startScale = 1)
	{
		ZoomFactor = zoomFactor;
		CurrentScale = startScale;
	}

	public void ChangeScale(bool doZoom)
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
	}
}
