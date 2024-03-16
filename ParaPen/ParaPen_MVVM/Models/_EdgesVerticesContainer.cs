using ParaPen.Models.CustomGraph;
using ParaPen.Models.CustomGraph.BlockNodes;
using System.Runtime.Serialization;

namespace ParaPen.Models;

//[Serializable]
//[XmlInclude(typeof(CountingLoopNode))]
//[XmlInclude(typeof(InkConditionNode))]
//[XmlInclude(typeof(InkPenActionNode))]
//[XmlInclude(typeof(SubprogramNode))]
//[XmlInclude(typeof(TerminalNode))]
//[XmlInclude(typeof(BlockNode))]
//[XmlInclude(typeof(BlockEdge))]

[KnownType(typeof(CountingLoopNode))]
[KnownType(typeof(InkConditionNode))]
[KnownType(typeof(InkPenActionNode))]
//[KnownType(typeof(SubprogramNode))] // note запрещена сериализация SubprogramNode. Разрешить, когда можно будет "развёртывать" SubprogramNode в обычные ноды
[KnownType(typeof(TerminalNode))]
[KnownType(typeof(BlockNode))]
[KnownType(typeof(BlockEdge))]
[DataContract]
public class _EdgesVerticesContainer
{
	[DataMember]
	public BlockNode[] Vertices { get; set; } = null!;

	[DataMember]
	public BlockEdge[] Edges { get; set; } = null!;

}
