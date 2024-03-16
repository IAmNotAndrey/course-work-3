using ParaPen.Models.Interfaces;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace ParaPen.Models.CustomGraph.BlockNodes;

[DebuggerDisplay("{Label}")]
[DataContract]
public abstract class BlockNode : INotifyPropertyChanged, IResetable
{
	public event PropertyChangedEventHandler? PropertyChanged;

	[DataMember]
	public string? Label { get; init; }

	private bool _isHighlighted;

	[IgnoreDataMember]
	public bool IsHighlighted
	{
		get => _isHighlighted;
		set
		{
			_isHighlighted = value;
			OnPropertyChanged(nameof(IsHighlighted));
		}
	}


	public BlockNode(bool isHighlighted = false)
	{
		IsHighlighted = isHighlighted;
	}


	public abstract bool Execute();

	public override string ToString()
	{
		return Label ?? $"{nameof(BlockNode)}";
	}

	protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}

	public virtual void Reset()
	{
		IsHighlighted = false;
	}
}
