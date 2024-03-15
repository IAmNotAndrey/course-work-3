using System;

namespace ParaPen.Models.CustomGraph.BlockNodes;

public class ConditionNode : BlockNode
{
    private readonly Func<bool> _condition;

	//public ConditionNode(string label, Func<bool> condition) : base(label)
	//{
	//    _condition = condition;
	//}
	public ConditionNode(Func<bool> condition)
	{
		_condition = condition;

		IsHighlighted = false;
	}

	/// <returns><see langword="bool"/> result of <see cref="_condition"/></returns>
	public override bool Execute()
    {
        return _condition.Invoke();
    }
}
