using ParaPen.Models.CustomGraph;
using ParaPen.Models.CustomGraph.BlockNodes;
using QuickGraph;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace ParaPen.Models;

[Serializable]
[KnownType(typeof(CountingLoopNode))]
[KnownType(typeof(InkConditionNode))]
[KnownType(typeof(InkPenActionNode))]
[KnownType(typeof(SubprogramNode))]
[KnownType(typeof(TerminalNode))]
[KnownType(typeof(BlockNode))]
[KnownType(typeof(BlockEdge))]
public class EdgesVerticesContainer
{
	public object[] Vertices { get; set; } = null!;
	public IEdge<object>[] Edges { get; set; } = null!;
}
