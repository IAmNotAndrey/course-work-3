using ParaPen.Models.Enums;
using System;
using System.Buffers;
using System.Windows.Controls;

namespace ParaPen.Models.CustomGraph.BlockNodes;

public class InkConditionNode : BlockNode
{
	public double StepMultiplier { get; init; }
	public Directions Direction { get; init; }

	public InkConditionNode(double stepMultiplier, Directions direction)
	{
		StepMultiplier = stepMultiplier;
		Direction = direction;

		Label = $"Is empty on {StepMultiplier}-{Direction}?";
		IsHighlighted = false;

		throw new NotImplementedException();
	}

	//todo ? что значит "есть место"?
	public ConditionNode ToConditionNode(InkPen inkPen, InkCanvas inkCanvas)
	{
		throw new NotImplementedException();
	}

	public override bool Execute()
	{
		throw new NotImplementedException();
	}
}
