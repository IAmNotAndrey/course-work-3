using QuickGraph;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ParaPen.Models.CustomGraph;

public class BlockDiagramGraph : BidirectionalGraph<object, IEdge<object>>
{
	// NOTE : не протестирован	
	public IEnumerable<object> GetAllConnectedVertices(object currentNode)
	{
		HashSet<object> visited = new();
		Queue<object> queue = new();

		queue.Enqueue(currentNode);
		visited.Add(currentNode);

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

	//public new object Clone()
	//{
	//	BlockDiagramGraph cloningGraph = new();

	//	// Клонируем вершины
	//	foreach (var vertex in Vertices)
	//	{
	//		cloningGraph.AddVertex(vertex);
	//	}

	//	// Клонируем рёбра
	//	foreach (var edge in Edges)
	//	{
	//		cloningGraph.AddEdge(edge);
	//	}

	//	return cloningGraph;
	//}
}
