using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace ParaPen.Models.CustomGraph;

[DebuggerDisplay("{Label}")]
public abstract class BlockNode : INotifyPropertyChanged
{
	public event PropertyChangedEventHandler? PropertyChanged;

	//public string Id { get; init; }

	public string Label { get; init; } = null!;

	private bool _isHighlighted;
	public bool IsHighlighted
	{
		get => _isHighlighted;
		set
		{
			_isHighlighted = value;
			OnPropertyChanged(nameof(IsHighlighted));
		}
	}

	public BlockNode(string label, bool isHighlighted = false)
	{
		//Id = id;
		Label = label;
	}


	public abstract bool Execute();

	public override string ToString()
	{
		return Label;
	}

	protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
