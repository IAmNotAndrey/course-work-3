﻿using System;

namespace ParaPen.Models.CustomGraph.BlockNodes;

public class ConditionNode : BlockNode
{
    public Func<bool> Condition { get; }

	//public ConditionNode(string label, Func<bool> condition) : base(label)
	//{
	//    _condition = condition;
	//}
	public ConditionNode(Func<bool> condition)
	{
		Condition = condition;

		IsHighlighted = false;
	}

	/// <returns><see langword="bool"/> result of <see cref="Condition"/></returns>
	public override bool Execute()
    {
        return Condition.Invoke();
    }
}
