using System;
using System.Runtime.Serialization;

namespace ParaPen.Models.CustomGraph.BlockNodes;

[DataContract]
public class TerminalNode : BlockNode
{
	[Obsolete]
	public TerminalNode() { }

    public TerminalNode(string label)
    {
		Label = label;
    }

    public override bool Execute() { return true; }

	//public override string ToString()
	//{
	//	return Label;
	//}
}
