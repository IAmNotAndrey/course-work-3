using System;

namespace ParaPen.Models.CustomGraph;

public class ConditionNode : BlockNode
{
	private readonly Func<bool> _condition;

	public ConditionNode(string label, Func<bool> condition) : base(label)
	{
		_condition = condition;
	}

	/// <returns><see langword="bool"/> result of <see cref="_condition"/></returns>
	public override bool Execute()
	{
		var b = _condition.Invoke();
		return _condition.Invoke();
	}
}
