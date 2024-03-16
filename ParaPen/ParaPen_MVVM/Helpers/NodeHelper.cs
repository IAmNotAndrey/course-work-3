using ParaPen.Models.CustomGraph;
using ParaPen.Models.CustomGraph.BlockNodes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ParaPen.Helpers;
public static class NodeHelper
{
	// TODO : упростить код


	/// <param name="node">OutEdges не может превышать 2</param>
	/// <param name="branchValue">По какой ветке будет осуществлён переход</param>	
	/// <exception cref="ArgumentException" /> // fixme : лучше другое исключение
	public static BlockNode? ReturnNextNode(this BlockNode node, bool branchValue, BlockDiagramGraph blockDiagram)
	{
		// Нахождение исходящих рёбер
		var outEdges = blockDiagram.OutEdges(node);

		if (outEdges.Count() > 2)
		{
			throw new ArgumentException($"{nameof(node)} cannot have more than 2 {nameof(outEdges)}", nameof(node));
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

	/// <summary>
	/// Меняет значение <paramref name="node"/>.IsHighlighted на противоположное
	/// </summary>
	/// <param name="node"></param>
	public static void ToggleHighlight(this BlockNode node)
	{
		node.IsHighlighted = !node.IsHighlighted;
	}

	/// <summary>
	/// Заменяет вершину на графе сохраняя рёбра
	/// </summary>
	[Obsolete]
	public static void ReplaceNode(BlockNode oldNode, BlockNode newNode, BlockDiagramGraph graph)
	{
		// Добавляем новую вершину на граф
		graph.AddVertex(newNode);

		List<BlockEdge> edgesToAdd = new();

		// Дублируем все входящие рёбра в `oldNode` для `newNode`
		foreach (var edge in graph.InEdges(oldNode).Cast<BlockEdge>())
		{
			var neighbor = edge.Source;
			// Добавить ребро между новой вершиной и соседней вершиной
			//graph.AddEdge(new BlockEdge(neighbor, newNode, edge.Value));
			edgesToAdd.Add(new BlockEdge(neighbor, newNode, edge.Value));
		}

		// Дублируем все выходящие рёбра в `oldNode` для `newNode`
		foreach (var edge in graph.OutEdges(oldNode).Cast<BlockEdge>())
		{
			var neighbor = edge.Target;
			// Добавить ребро между новой вершиной и соседней вершиной
			//newGraph.AddEdge(new BlockEdge(newNode, neighbor, edge.Value));
			edgesToAdd.Add(new BlockEdge(newNode, neighbor, edge.Value));
		}

		// Удаляем `oldNode` и все связанные с ней рёбра из графа
		graph.RemoveVertex(oldNode);

		graph.AddEdgeRange(edgesToAdd);
	}

	/// <summary>
	/// Находит начальную <see cref="TerminalNode"/> в <paramref name="graph"/>
	/// </summary>
	/// <returns><see cref="TerminalNode"/> или <see langword="null"/>, если вершина не была найдена или было найдено более 1 совпадений</returns>
	public static TerminalNode? GetStartNode(BlockDiagramGraph graph)
	{
		return (TerminalNode?)graph.Vertices
			.SingleOrDefault(v =>
				v is TerminalNode
				&& graph.OutEdges(v).Count() == 1
			);
	}
}
