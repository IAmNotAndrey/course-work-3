﻿using System;

namespace ParaPen.Models.CustomGraph;

public class ActionNode : BlockNode
{
    private readonly Action _action;

    public ActionNode(string id, string label, Action action) : base(id, label)
    {
        _action = action;
    }

	/// <returns><see langword="true"/></returns>
	public override bool Execute()
	{
		_action.Invoke();
        return true;
	}
}