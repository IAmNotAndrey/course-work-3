using ParaPen.Commands;
using ParaPen.Models.CustomGraph;
using System;

namespace ParaPen.ModelViews;

public class ChangeHighlightingCommand : CommandBase
{
	public event EventHandler? CanExecuteChanged;

    public override void Execute(object? parameter)
	{
		if (parameter is not BlockNode blockNode)
		{
			throw new ArgumentException($"{nameof(parameter)} must be one of the subclasses of the {typeof(BlockNode)} class. {parameter?.GetType()} given.", nameof(parameter));
		}

		blockNode.IsHighlighted = !blockNode.IsHighlighted;
	}
}