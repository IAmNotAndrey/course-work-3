using ParaPen.Models.CustomGraph.BlockNodes;
using QuickGraph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ParaPen.Models.CustomGraph;

[Serializable]
[KnownType(typeof(CountingLoopNode))]
[KnownType(typeof(InkConditionNode))]
[KnownType(typeof(InkPenActionNode))]
[KnownType(typeof(SubprogramNode))]
[KnownType(typeof(TerminalNode))]
[KnownType(typeof(BlockNode))]
[KnownType(typeof(BlockEdge))]
public class BlockDiagramGraph : BidirectionalGraph<object, IEdge<object>>
{
	public IEnumerable<object> GetAllConnectedVertices(object v)
	{
		HashSet<object> visited = new();
		Queue<object> queue = new();

		queue.Enqueue(v);
		visited.Add(v);

		while (queue.Count > 0)
		{
			object current = queue.Dequeue();

			foreach (var edge in this.InEdges(current).Concat(this.OutEdges(current)))
			{
				object neighbor = edge.Source == current ? edge.Target : edge.Source;

				if (visited.Add(neighbor))
				{
					queue.Enqueue(neighbor);
				}
			}
		}

		return visited;
	}

	public void RemoveVertexRange(IEnumerable<object> vs)
	{
		foreach (object v in vs) 
		{
			this.RemoveVertex(v);
		}
	}

	public IEnumerable<IEdge<object>> GetAllEdges(IEnumerable<object> vs)
	{
		HashSet<IEdge<object>> edges = new();
		foreach (var node in vs)
		{
			var edgesOfNode = this.InEdges(node).Concat(this.OutEdges(node));
			edges.UnionWith(edgesOfNode);
		}
		return edges;
	}
}
