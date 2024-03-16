using ParaPen.Models.CustomGraph.BlockNodes;
using QuickGraph;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace ParaPen.Models.CustomGraph;

[DebuggerDisplay("{Label}")]
//[Serializable]
[KnownType(typeof(CountingLoopNode))]
[KnownType(typeof(InkConditionNode))]
[KnownType(typeof(InkPenActionNode))]
//[KnownType(typeof(SubprogramNode))] // note запрещена сериализация SubprogramNode. Разрешить, когда можно будет "развёртывать" SubprogramNode в обычные ноды
[KnownType(typeof(TerminalNode))]
[KnownType(typeof(BlockNode))]
[KnownType(typeof(BlockEdge))]
[DataContract]
public class BlockEdge : IEdge<object>, INotifyPropertyChanged
{
	public event PropertyChangedEventHandler? PropertyChanged;

	//public string Id { get; init; }
	[DataMember]
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

	[DataMember]
	public object Source { get; init; }

	[DataMember]
	public object Target { get; init; }

	//[XmlIgnore]
	[IgnoreDataMember]
	public bool IsLooped => Source == Target;

    public BlockEdge() { }

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
