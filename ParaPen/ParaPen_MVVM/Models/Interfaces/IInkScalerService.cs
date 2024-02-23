namespace ParaPen_MVVM.Models.Interfaces;

public interface IInkScalerService
{
	double ZoomFactor { get; }
	double CurrentScale { get; }
	void ChangeScale(bool doZoom);
}
