using ParaPen.Models;
using ParaPen.Models.CustomGraph;
using ParaPen.Models.CustomGraph.BlockNodes;
using ParaPen.Models.Enums;
using QuickGraph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using static ParaPen.Models.StaticResources.StaticResources;

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

	#region ActionGetters

	public static Action GetActionOutOfPenActions(double stepMultiplier, PenActions penAction, Directions direction, InkPen inkPen, InkCanvas inkCanvas)
	{
		Vector vectorStep = DirectionVectorDict[direction] * stepMultiplier;

		Action action = penAction switch
		{
			PenActions.Move => () => inkPen.MoveOffset(vectorStep),
			PenActions.Draw => () => inkPen.DrawLine(vectorStep, inkCanvas),
			_ => throw new ArgumentException(null, nameof(penAction)),
		};

		return action;
	}

	//todo
	public static Func<bool> GetBoolActionOutOf___()
	{
		throw new NotImplementedException();
	}

	#endregion

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

		// fixme ? ссылка не изменяется? должна изменяться - не слушай IDE
	}
}
