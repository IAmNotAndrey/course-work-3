using System;

namespace ParaPen.Models.Blocks;

public class ActionNode : BlockNode
{
    private readonly Action _action;

    public ActionNode(string label, Action action)
    {
        Label = label;
        _action = action;
    }

	/// <returns><see langword="true"/></returns>
	public override bool Execute()
	{
		_action.Invoke();
        return true;
	}
}
