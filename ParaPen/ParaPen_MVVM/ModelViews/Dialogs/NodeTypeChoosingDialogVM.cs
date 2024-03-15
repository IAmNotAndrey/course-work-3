using ParaPen.Commands.Nodes;
using ParaPen.Models.CustomGraph.BlockNodes;
using System;
using System.Windows.Input;

namespace ParaPen.ModelViews.Dialogs;

public class NodeTypeChoosingDialogVM : DialogVMBase
{
	public static Type[] NodeTypes => new Type[] 
	{
		typeof(InkConditionNode), 
		typeof(CountingLoopNode),
		typeof(InkPenActionNode),
		typeof(SubprogramNode),
	};

	public Type? ChosenType { get; set; }
	
	public ICommand OkCommand => new ChooseNodeTypeCommand(this);
	
	// todo
}
