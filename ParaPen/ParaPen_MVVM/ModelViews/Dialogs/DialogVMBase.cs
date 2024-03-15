using ParaPen.Commands;
using System;
using System.Windows.Input;

namespace ParaPen.ModelViews.Dialogs;

public class DialogVMBase : ViewModelBase
{
	public ICommand CancelCommand => new WindowCloseCommand();
}
