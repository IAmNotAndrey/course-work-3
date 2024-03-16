using ParaPen.Models.CustomGraph.BlockNodes;
using QuickGraph;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace ParaPen.Models.CustomGraph;

[DebuggerDisplay("{Label}")]
[KnownType(typeof(CountingLoopNode))]
[KnownType(typeof(InkConditionNode))]
[KnownType(typeof(InkPenActionNode))]
//[KnownType(typeof(SubprogramNode))] // note запрещена сериализация SubprogramNode. Разрешить, когда можно будет "развёртывать" SubprogramNode в обычные ноды
[KnownType(typeof(TerminalNode))]
[KnownType(typeof(BlockNode))]
[KnownType(typeof(BlockEdge))]
[DataContract]
public class BlockEdge : IEdge<object>
{
	[DataMember]
	public bool Value { get; init; }

	[DataMember]
	public object Source { get; init; }

	[DataMember]
	public object Target { get; init; }

	[IgnoreDataMember]
	public bool IsLooped => Source == Target;

    public BlockEdge() { }

    public BlockEdge(object source, object target, bool value=true)
	{
		Value = value;
		Source = source;
		Target = target;
	}
}
