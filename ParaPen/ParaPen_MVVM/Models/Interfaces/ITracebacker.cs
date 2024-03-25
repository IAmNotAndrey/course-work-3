using System.Collections.ObjectModel;

namespace ParaPen.Models.Interfaces;

public interface ITracebacker : IResetable
{
	ObservableCollection<TracebackItem> Items { get; }

	void Log(TracebackItem item);
}
