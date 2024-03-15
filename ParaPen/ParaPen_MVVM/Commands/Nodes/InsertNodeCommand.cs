using ParaPen.Models.CustomGraph;
using ParaPen.Models.CustomGraph.BlockNodes;
using ParaPen.ModelViews;
using ParaPen.ModelViews.Dialogs;
using ParaPen.Views;
using System;
using System.Windows;

namespace ParaPen.Commands.Nodes;

public class InsertNodeCommand : CommandBase
{
	private readonly BlockDiagramGraph _blockDiagramGraph;

	public InsertNodeCommand(BlockDiagramGraph blockDiagram)
	{
		_blockDiagramGraph = blockDiagram;
	}

	/// <param name="parameter">Edge</param>
	public override void Execute(object? parameter)
	{
		if (parameter is not BlockEdge edge)
		{
			throw new ArgumentException(null, nameof(edge));
		}

		// Открываем диалоговое окно выбора BlockNode и пытаемся получить оттуда тип добавляемой BlockNode
		NodeChoosingDialog nodeTypeChoosingDialog = new();
		nodeTypeChoosingDialog.ShowDialog();
		Type? creatingNodeType = ((NodeTypeChoosingDialogVM)nodeTypeChoosingDialog.DataContext).ChosenType;
		if (creatingNodeType is null)
		{
			return;
		}


		Window dialog;
		// Вызов соответствующих диалоговых окон для установления `BlockNode` и их возврата через `CreatedNode`
		if (creatingNodeType.Equals(typeof(InkConditionNode)))
		{
			dialog = new InkConditionDialog();
		}
		else if (creatingNodeType.Equals(typeof(CountingLoopNode)))
		{
			dialog = new CountingLoopDialog();
		}
		else if (creatingNodeType.Equals(typeof(InkPenActionNode)))
		{
			dialog = new InkPenActionDialog();
		}
		else if (creatingNodeType.Equals(typeof(SubprogramNode)))
		{
			throw new NotImplementedException();
		}
		else
		{
			throw new ArgumentException(null, nameof(creatingNodeType)); 
		}

		dialog.ShowDialog();
		BlockNode? nodeToAdd = ((NodeSetDialogVMBase)dialog.DataContext).CreatedNode;

		if (nodeToAdd is null)
		{
			return;
		}

		var s = edge.Source;
		var t = edge.Target;

		_blockDiagramGraph.RemoveEdge(edge);

		_blockDiagramGraph.AddVertex(nodeToAdd);

		// CountingLoopNode, то добавляем ребро ссылающееся на саму CountingLoopNode с значением `false`
		if (nodeToAdd is CountingLoopNode)
		{
			_blockDiagramGraph.AddEdge(new BlockEdge(nodeToAdd, nodeToAdd, false));
		}
		if (nodeToAdd is InkConditionNode)
		{
			//fixme 
			_blockDiagramGraph.AddEdge(new BlockEdge(nodeToAdd, t, false));
		}
		//fixme edge.Value возникали ошибки с `CountingLoopNode`
		_blockDiagramGraph.AddEdge(new BlockEdge(s, nodeToAdd, edge.Value));
		_blockDiagramGraph.AddEdge(new BlockEdge(nodeToAdd, t));

		//throw new NotImplementedException();
	}
}
