using ParaPen.Commands;
using ParaPen.Commands.Nodes;
using System.Windows.Input;

namespace ParaPen.ModelViews.Dialogs;

public class EdgeTypeChoosingDialogVM : DialogVMBase
{
	public bool? ChosenEdgeValue { get; set; }

	public ICommand OkCommand => new ChooseEdgeValueCommand(this);
}
