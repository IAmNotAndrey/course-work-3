using System;

namespace ParaPen.Models.CustomGraph.BlockNodes;

[Serializable]
public class TerminalNode : BlockNode
{
	[Obsolete]
	public TerminalNode() { }

    public TerminalNode(string label)
    {
		Label = label;
    }

    public override bool Execute() { return true; }

	public override string ToString()
	{
		return Label;
	}
}
