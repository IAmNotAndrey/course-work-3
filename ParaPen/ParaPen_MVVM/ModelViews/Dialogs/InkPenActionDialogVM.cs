using ParaPen.Commands.Nodes;
using ParaPen.Models.Enums;
using System;
using System.Windows.Input;

namespace ParaPen.ModelViews.Dialogs;

public class InkPenActionDialogVM : NodeSetDialogVMBase
{
	public static Array PenActionsValues => Enum.GetValues(typeof(PenActions));
	public static Array DirectionsValues => Enum.GetValues(typeof(Directions));

	//public ICommand OkCommand => new CreateInkPenActionNode(CreatedNode);
	public ICommand OkCommand => new CreateInkPenActionNodeCommand(this);
}
