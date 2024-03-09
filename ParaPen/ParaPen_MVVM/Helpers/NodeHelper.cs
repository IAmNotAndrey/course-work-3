using ParaPen.Models.CustomGraph;
using ParaPen.ModelViews;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System;
using System.Linq;
using ParaPen.Models.CustomGraph.BlockNodes;

namespace ParaPen.Helpers;
public static class NodeHelper
{
	// TODO : упростить код

	/// <summary>
	/// 
	/// </summary>
	/// <param name="node"></param>
	/// <param name="branchValue">По какой ветке будет осуществлён переход</param>
	/// <param name="blockDiagram"></param>
	/// <returns></returns>
	/// <exception cref="ArgumentException"></exception>
	public static BlockNode? ReturnNextNode(BlockNode node, bool branchValue, BlockDiagramGraph blockDiagram)
	{
		// Нахождение исходящих рёбер
		var outEdges = blockDiagram.OutEdges(node);

		if (outEdges.Count() > 2)
		{
			throw new ArgumentException($"{nameof(node)} cannot have more than 2 {nameof(outEdges)}", nameof(outEdges));
		}

		// Приводим все рёбра к типу `BlockEdge`. Если cast неудачный, то выдаст исключение
		IEnumerable<BlockEdge> outBlockEdges = outEdges.Cast<BlockEdge>();

		// Получаем необходимую `BlockEdge` в виде `object`
		BlockEdge? nesEdge = outBlockEdges.SingleOrDefault(edge => edge.Value == branchValue);

		// Если нет исходящих рёбер, значит на вход дан `EndNode`
		if (nesEdge is null)
		{
			return null;
		}

		// Получаем вершину на конце `nesEdge`. Вызовет `CastException` при неудачном кастинге
		BlockNode target = (BlockNode)nesEdge.Target;

		return target;
	}

	public static void ToggleHighlight(this BlockNode? node)
	{
		if (node is not null)
		{
			node.IsHighlighted = !node.IsHighlighted;
		}
	}
}
