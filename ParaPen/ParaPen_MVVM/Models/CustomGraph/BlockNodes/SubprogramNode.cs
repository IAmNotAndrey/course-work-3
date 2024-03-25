using ParaPen.Models.Interfaces;
using QuickGraph;
using System;
using System.Collections.Generic;
using static ParaPen.Helpers.NodeHelper;

namespace ParaPen.Models.CustomGraph.BlockNodes;

public class SubprogramNode : BlockNode, IResetable
{
	private readonly BlockPenContainer _container;

	[Obsolete]
	public SubprogramNode() { }

	public SubprogramNode(BlockPenContainer container, IEnumerable<IEdge<object>> edges, string label)
	{
		BlockDiagramGraph localBlockDiagram = new();
		localBlockDiagram.AddVerticesAndEdgeRange(edges);

		// NOTE создаём с пустым конструктором, так как нам не нужно привязываться к событию `userViewMover.UserViewOffsetChanged`: `InkPen` уже на него реагирует
		_container = new BlockPenContainer()
		{
			InkCanvas = container.InkCanvas,
			InkPen = container.InkPen,
			StartNode = GetStartNode(localBlockDiagram) ?? throw new ArgumentException($"{nameof(edges)} has no start vertex", nameof(edges)),
			BlockDiagramGraph = localBlockDiagram
		};
		// Устанавливаем `SelectedNode`
		_container.Reset();

		//FIXME
		//Label = "Subprogram";
		Label = label;
	}


	public override bool Execute()
	{
		BlockNode node = _container.SelectedNode!;

		bool branchValue = node.Execute();

		BlockNode? target = node.ReturnNextNode(branchValue, _container.BlockDiagramGraph);
		_container.SelectedNode = target;

		// Если target is null, значит работа подпрограммы закончилась
		if (target is null)
		{
			//NOTE? можно прогонять ноду через цикл. reset? 
			Reset();
			return false;
		}
		return true;
	}

	public override void Reset()
	{
		_container.Reset();
		base.Reset();
	}
}
