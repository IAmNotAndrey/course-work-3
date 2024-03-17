using ParaPen.Models.CustomGraph.BlockNodes;
using ParaPen.Models.Enums;
using ParaPen.ModelViews.Dialogs;
using System;
using static ParaPen.Models.StaticResources.AppConfigs;

namespace ParaPen.Commands.Nodes;

public class CreateInkPenActionNodeCommand : CommandBase
{
	private readonly NodeSetDialogVMBase _vm;

	public CreateInkPenActionNodeCommand(NodeSetDialogVMBase vm)
    {
        _vm = vm;
    }

	
    /// <param name="parameter">{PenAction, Direction}</param>
    public override void Execute(object? parameter)
	{
		if (parameter is not object[] values || values.Length != 2)
		{
			throw new ArgumentException(null, nameof(parameter));
		}

		var penAction = (PenActions)values[0];
		var direction = (Directions)values[1];

		//_inkPenActionNode = new InkPenActionNode(STEP_VALUE, penAction, direction);

		// fixme небезопасно
		_vm.CreatedNode = new InkPenActionNode(STEP_VALUE, penAction, direction);
	}

	//fixme
	//public override bool CanExecute(object? parameter)
	//{
	//	return base.CanExecute(parameter);
	//}
}
