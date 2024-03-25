using ParaPen.Models.Interfaces;
using System.Collections.ObjectModel;

namespace ParaPen.Models;

public class Tracebacker : ITracebacker
{
	public ObservableCollection<TracebackItem> Items { get; } = new();

	public void Log(TracebackItem item)
	{
		Items.Add(item);
	}

	public void Reset()
	{
		Items.Clear();
	}
}
