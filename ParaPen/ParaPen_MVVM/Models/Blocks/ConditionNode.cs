using System;

namespace ParaPen.Models.Blocks;

public class ConditionNode : BlockNode
{
	private readonly Func<bool> _condition;

	public ConditionNode(string label, Func<bool> condition)
	{
		Label = label;
		_condition = condition;
	}

	/// <returns><see langword="bool"/> result of <see cref="_condition"/></returns>
	public override bool Execute()
	{
		return _condition.Invoke();
	}
}
