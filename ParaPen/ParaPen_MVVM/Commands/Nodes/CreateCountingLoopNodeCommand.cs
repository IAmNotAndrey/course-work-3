using ParaPen.Models.CustomGraph.BlockNodes;
using ParaPen.ModelViews.Dialogs;
using System;

namespace ParaPen.Commands.Nodes;

public class CreateCountingLoopNodeCommand : CommandBase
{
	private readonly NodeSetDialogVMBase _vm;

	public CreateCountingLoopNodeCommand(NodeSetDialogVMBase vm)
    {
		_vm = vm;
	}

	/// <param name="parameter">{int count}</param>
	public override void Execute(object? parameter)
	{
		if (parameter is not int count)
		{
			throw new ArgumentException(null, nameof(parameter));
		}

		_vm.CreatedNode = new CountingLoopNode((uint)count);
	}

	public override bool CanExecute(object? parameter)
	{
		return parameter is int count && count > 0;
	}
}
