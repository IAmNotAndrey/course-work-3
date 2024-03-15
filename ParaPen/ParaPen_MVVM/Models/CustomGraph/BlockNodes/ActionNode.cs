using System;

namespace ParaPen.Models.CustomGraph.BlockNodes;

public class ActionNode : BlockNode
{
    public Action Action { get; }

    public ActionNode(Action action)
    {
        Action = action;

        IsHighlighted = false;
        Label = $"{action}";
	}

    //public ActionNode(string label, Action action) : base(label)
    //{
    //    _action = action;
    //}

    /// <returns><see langword="true"/></returns>
    public override bool Execute()
    {
        Action.Invoke();
        return true;
    }

	//public override string ToString()
	//{
	//	return $"{base.ToString()}-Action-{_action}";
	//}
}
