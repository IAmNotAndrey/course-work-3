using System;

namespace ParaPen.Models.Blocks;

public class ActionNode : BlockNode<object?>
{
    private readonly Action _action;

    public ActionNode(string label, Action action)
    {
        Label = label;
        _action = action;
    }

	/// <returns><see langword="null"/></returns>
	public override object? Execute()
	{
		_action.Invoke();
        return null;
	}
}
