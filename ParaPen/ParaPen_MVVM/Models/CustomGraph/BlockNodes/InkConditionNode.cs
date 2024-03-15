﻿using ParaPen.Models.Enums;
using System;
using System.Windows;
using System.Windows.Controls;
using static ParaPen.Helpers.InkCanvasMethods;
using static ParaPen.Models.StaticResources.StaticResources;

namespace ParaPen.Models.CustomGraph.BlockNodes;

public class InkConditionNode : BlockNode
{
	public double StepValue { get; init; }
	public Directions Direction { get; init; }

	public Func<bool>? Condition { get; set; }


	public InkConditionNode(double stepValue, Directions direction)
	{
		StepValue = stepValue;
		Direction = direction;

		Label = $"Is empty on {StepValue}-{Direction}?";
		IsHighlighted = false;
	}

	// NOTE ? что значит "есть место"? -- определил, как есть ли штрихи на этом месте
	public ConditionNode ToConditionNode(InkPen inkPen, InkCanvas inkCanvas)
	{
		Vector vectorStep = DirectionVectorDict[Direction] * StepValue;
		Point pointToCheck = inkPen.CurCords + vectorStep;

		Func<bool> condition = () => IsStrokeAtPoint(pointToCheck, inkCanvas);

		return new ConditionNode(condition);
	}

	public override bool Execute()
	{
		if (Condition is null)
		{
			throw new NullReferenceException(nameof(Action));
		}
		return Condition.Invoke();
	}
}
