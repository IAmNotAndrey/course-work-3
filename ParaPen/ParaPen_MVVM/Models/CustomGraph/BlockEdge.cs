using QuickGraph;
using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace ParaPen.Models.CustomGraph;

[DebuggerDisplay("{Label}")]	
public class BlockEdge : IEdge<object>, INotifyPropertyChanged
{
	public event PropertyChangedEventHandler? PropertyChanged;

	//public string Id { get; init; }
	public bool Value { get; init; }

	//private bool _isHighlighted;
	//public bool IsHighlighted
	//{
	//	get { return _isHighlighted; }
	//	set
	//	{
	//		if (_isHighlighted != value)
	//		{
	//			_isHighlighted = value;
	//			OnPropertyChanged(nameof(IsHighlighted));
	//		}
	//	}
	//}

	public object Source { get; init; }
	public object Target { get; init; }

	public bool IsLooped => Source == Target;

	public BlockEdge(object source, object target, bool value=true)
	{
		//Id = id;
		Value = value;
		Source = source;
		Target = target;
	}


	//protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
	//{
	//	PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	//}
}
