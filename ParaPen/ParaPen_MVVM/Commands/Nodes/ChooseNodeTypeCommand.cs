﻿using ParaPen.ModelViews.Dialogs;
using System;

namespace ParaPen.Commands.Nodes;

public class ChooseNodeTypeCommand : CommandBase
{
	private readonly NodeTypeChoosingDialogVM _vm;

	public ChooseNodeTypeCommand(NodeTypeChoosingDialogVM vm)
    {
		_vm = vm;
    }

    public override void Execute(object? parameter)
	{
		if (parameter is not Type type)
		{
			throw new ArgumentException(null, nameof(parameter));
		}
		//fixme небезопасно
		_vm.ChosenType = type;
	}

	//fixme 
	//public override bool CanExecute(object? parameter)
	//{
	//	return base.CanExecute(parameter);
	//}
}
