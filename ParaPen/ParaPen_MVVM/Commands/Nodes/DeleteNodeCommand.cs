using ParaPen.Models.CustomGraph;
using ParaPen.Models.CustomGraph.BlockNodes;
using ParaPen.ModelViews;
using QuickGraph;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ParaPen.Commands.Nodes;

public class DeleteNodeCommand : CommandBase
{
	private readonly BlockDiagramVM _vm;

	public DeleteNodeCommand(BlockDiagramVM vm)
	{
		_vm = vm;
	}

	// FIXME могу неправильно работать - протестируй меня
	/// <param name="parameter">{BlockNode}</param>
	public override void Execute(object? parameter)
	{
		if (parameter is not BlockNode node)
		{
			throw new ArgumentException("Parameter must be a BlockNode", nameof(parameter));
		}

		IEnumerable<IEdge<object>> inEdges = _vm.BlockDiagram.InEdges(node);
		//IEnumerable<IEdge<object>> inEdges;

		var posNextNodeOnTrue = Helpers.NodeHelper.ReturnNextNode(node, true, _vm.BlockDiagram);
		var posNextNodeOnFalse = Helpers.NodeHelper.ReturnNextNode(node, false, _vm.BlockDiagram);

		BlockNode nextNode = posNextNodeOnFalse ?? posNextNodeOnTrue ?? throw new NullReferenceException(nameof(posNextNodeOnTrue));

		if (posNextNodeOnFalse != null)
		{
			if (node is not InkConditionNode)
			{
				// Находим ребро со значением false
				var edge = _vm.BlockDiagram.OutEdges(node).Single(e => ((BlockEdge)e).Value == false);
				// Удаляем ребро, для того, чтобы удалить только вершины находящиеся внутри тела цикла
				_vm.BlockDiagram.RemoveEdge(edge);
			}
			// Удаляем все вершины внутри тела цикла и саму вершину цикла
			Helpers.NodeHelper.RecursivelyRemoveAllNextNodes(node, _vm.BlockDiagram);

		}

		foreach (var ie in inEdges)
		{
			// fixme : не использовать исключения
			try
			{
				_vm.BlockDiagram.AddEdge(new BlockEdge(ie.Source, nextNode, ((BlockEdge)ie).Value));
			}
			catch
			{
				continue;
			}
		}

		_vm.BlockDiagram.RemoveVertex(node);


		//foreach (var edge in inEdges)
		//{
		//	var source = edge.Source;
		//	var value = ((BlockEdge)edge).Value;
		//	_vm.BlockDiagram.AddEdge(new BlockEdge(source, posNextNode2 ?? posNextNode1!, value));
		//}

		// todo Удаляем все оставшиеся вершины, которые лежат в теле вероятного цикла
		// BUG будет неправильно работать с InkConditionNode


		// Удаляем false-ветку, чтобы случайно не удалить 

	}
}
