using ParaPen.Models;
using ParaPen.Models.CustomGraph;
using QuickGraph;
using System.Collections.Generic;
using System.Linq;

namespace ParaPen.Helpers;

public static class EdgeHelper
{
	/// <summary>
	/// Пытается получить <see cref="BlockPenContainer"/>, в котором присутствует <paramref name="edge"/>
	/// </summary>
	public static BlockPenContainer? GetBlockPenContainer(this IEnumerable<BlockPenContainer> containers, BlockEdge edge, BlockDiagramGraph graph)
	{
		return containers.SingleOrDefault(c =>
		{
			return graph.GetAllEdges(graph.GetAllConnectedVertices(c.StartNode))
						.FirstOrDefault(e => e == edge) != null;
		});
	}
}
