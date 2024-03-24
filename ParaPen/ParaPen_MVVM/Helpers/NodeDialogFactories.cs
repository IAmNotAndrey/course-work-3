using ParaPen.Helpers.Interfaces;
using ParaPen.Views;
using System.Windows;

namespace ParaPen.Helpers;


public class InkConditionNodeDialogFactory : INodeDialogFactory
{
	public Window CreateDialog()
	{
		return new InkConditionDialog();
	}
}

public class CountingLoopNodeDialogFactory : INodeDialogFactory
{
	public Window CreateDialog()
	{
		return new CountingLoopDialog();
	}
}

public class InkPenActionNodeDialogFactory : INodeDialogFactory
{
	public Window CreateDialog()
	{
		return new InkPenActionDialog();
	}
}
