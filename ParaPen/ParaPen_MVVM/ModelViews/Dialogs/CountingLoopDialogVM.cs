using ParaPen.Commands.Nodes;
using System.Windows.Input;

namespace ParaPen.ModelViews.Dialogs;

public class CountingLoopDialogVM : NodeSetDialogVMBase
{
	public ICommand OkCommand => new CreateCountingLoopNodeCommand(this);
}
