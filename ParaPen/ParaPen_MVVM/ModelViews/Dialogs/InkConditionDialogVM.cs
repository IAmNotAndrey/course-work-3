using ParaPen.Commands.Nodes;
using ParaPen.Models.Enums;
using System;
using System.Windows.Input;

namespace ParaPen.ModelViews.Dialogs;

public class InkConditionDialogVM : NodeSetDialogVMBase
{
	public static Array DirectionsValues => Enum.GetValues(typeof(Directions));

	public ICommand OkCommand => new CreateInkConditionNodeCommand(this);
}
