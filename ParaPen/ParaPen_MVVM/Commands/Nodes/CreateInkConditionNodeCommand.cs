using System;
using ParaPen.Models.CustomGraph.BlockNodes;
using ParaPen.Models.Enums;
using ParaPen.ModelViews.Dialogs;
using static ParaPen.Models.StaticResources.StaticResources;

namespace ParaPen.Commands.Nodes;

public class CreateInkConditionNodeCommand : CommandBase
{
	private readonly NodeSetDialogVMBase _vm;

	public CreateInkConditionNodeCommand(NodeSetDialogVMBase vm)
	{
		_vm = vm;
	}

	/// <param name="parameter">{int Steps, Direction}</param>
	public override void Execute(object? parameter)
	{
		if (parameter is not object[] values || values.Length != 2)
		{
			throw new ArgumentException(null, nameof(parameter));
		}

		var steps = (int)values[0];
		var direction = (Directions)values[1];

		//_inkPenActionNode = new InkPenActionNode(STEP_VALUE, penAction, direction);
		// fixme небезопасно
		_vm.CreatedNode = new InkConditionNode(steps * STEP_VALUE, direction);
	}
}

	//todo должен запрещать передачу steps < 0 (не uint)
//	public override bool CanExecute(object? parameter)
//	{
//		return base.CanExecute(parameter);
//	}
//}
