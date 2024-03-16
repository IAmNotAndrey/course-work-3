using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace ParaPen.Models.CustomGraph.BlockNodes;

[DebuggerDisplay("{Label}")]
//[Serializable]
[DataContract]
public abstract class BlockNode : INotifyPropertyChanged
{
	public event PropertyChangedEventHandler? PropertyChanged;

	//public string Id { get; init; }
	[DataMember]
	public string? Label { get; init; }

	private bool _isHighlighted;
	//[XmlIgnore]
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

	//public BlockNode(string label, bool isHighlighted = false)
	//{
	//	//Id = id;
	//	Label = label;
	//	IsHighlighted = isHighlighted;
	//}


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
