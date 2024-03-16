using ParaPen.Models;
using ParaPen.Models.CustomGraph;
using ParaPen.Models.CustomGraph.BlockNodes;
using ParaPen.ModelViews.Dialogs;
using ParaPen.Views;
using System;
using System.Collections.Generic;
using System.Windows;
using ParaPen.Helpers;
using ParaPen.Helpers.Interfaces;

namespace ParaPen.Commands.Nodes;

public class InsertNodeCommand : CommandBase
{
	private readonly BlockDiagramGraph _blockDiagramGraph;
	private readonly IEnumerable<BlockPenContainer> _bpContainers;

	public InsertNodeCommand(BlockDiagramGraph blockDiagram, IEnumerable<BlockPenContainer> bpContainers)
	{
		_blockDiagramGraph = blockDiagram;
		_bpContainers = bpContainers;
	}

	/// <param name="parameter">Edge</param>
	public override void Execute(object? parameter)
	{
		if (parameter is not BlockEdge edge)
		{
			throw new ArgumentException(null, nameof(parameter));
		}
		
		// Открываем диалог с выбором типа вершины
		NodeChoosingDialog nodeTypeChoosingDialog = new();
		nodeTypeChoosingDialog.ShowDialog();
		Type? creatingNodeType = ((NodeTypeChoosingDialogVM)nodeTypeChoosingDialog.DataContext).ChosenType;
		if (creatingNodeType is null)
		{
			return;
		}

		// Открываем диалоги для создания вершин
		BlockNode? nodeToAdd;
		if (TryCreateDialog(creatingNodeType, out Window? dialog))
		{
			dialog?.ShowDialog();
			nodeToAdd = ((NodeSetDialogVMBase)dialog.DataContext).CreatedNode;
		}
		else if (creatingNodeType.Equals(typeof(SubprogramNode)))
		{
			nodeToAdd = CreateSubprogramNode(edge);
		}
		else
		{
			throw new ArgumentException(null, nameof(creatingNodeType));
		}

		if (nodeToAdd is null)
		{
			return;
		}

		var s = edge.Source;
		var t = edge.Target;

		// Удаляем ребро, в которое вставляем вершину
		_blockDiagramGraph.RemoveEdge(edge);
		// Добавляем новую вершину
		_blockDiagramGraph.AddVertex(nodeToAdd);

		// Если добавляемая вершина CountingLoopNode или SubprogramNode, то ей дополнительно добавляем петлю с значением false
		if (nodeToAdd is CountingLoopNode || nodeToAdd is SubprogramNode)
		{
			_blockDiagramGraph.AddEdge(new BlockEdge(nodeToAdd, nodeToAdd, false));
		}
		// Если InkConditionNode, то добавляем дополнительное выходящее false-ребро 
		else if (nodeToAdd is InkConditionNode)
		{
			_blockDiagramGraph.AddEdge(new BlockEdge(nodeToAdd, t, false));
		}

		// Соединяем новую вершину с предыдущей и последующей
		_blockDiagramGraph.AddEdge(new BlockEdge(s, nodeToAdd, edge.Value));
		_blockDiagramGraph.AddEdge(new BlockEdge(nodeToAdd, t));
	}

	private static bool TryCreateDialog(Type creatingNodeType, out Window? dialog)
	{
		dialog = null;
		Dictionary<Type, INodeDialogFactory> dialogFactories = new()
		{
			{ typeof(InkConditionNode), new InkConditionNodeDialogFactory() },
			{ typeof(CountingLoopNode), new CountingLoopNodeDialogFactory() },
			{ typeof(InkPenActionNode), new InkPenActionNodeDialogFactory() }
		};

		if (dialogFactories.TryGetValue(creatingNodeType, out var factory))
		{
			dialog = factory.CreateDialog();
		}

		return dialog != null;
	}

	private BlockNode? CreateSubprogramNode(BlockEdge edge)
	{
		NodeSetDialogVMBase vm = new();
		BlockPenContainer bpContainer = _bpContainers.GetBlockPenContainer(edge, _blockDiagramGraph)
			?? throw new NullReferenceException(nameof(bpContainer));

		var command = new CreateSubprogramNodeCommand(vm, bpContainer);
		command.Execute(null);
		return vm.CreatedNode;
	}
}
