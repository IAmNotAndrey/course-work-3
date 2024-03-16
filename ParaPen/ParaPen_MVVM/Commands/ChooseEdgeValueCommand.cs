using ParaPen.ModelViews.Dialogs;
using System;

namespace ParaPen.Commands;

public class ChooseEdgeValueCommand : CommandBase
{
	private readonly EdgeTypeChoosingDialogVM _vm;

	public ChooseEdgeValueCommand(EdgeTypeChoosingDialogVM vm)
    {
		_vm = vm;
	}

	/// <param name="parameter"><see langword="bool" /> edgeValue</param>
	public override void Execute(object? parameter)
	{
		if (parameter is not bool edgeValue)
		{
			throw new ArgumentException(null, nameof(parameter));
		}

		_vm.ChosenEdgeValue = edgeValue;
	}
}
