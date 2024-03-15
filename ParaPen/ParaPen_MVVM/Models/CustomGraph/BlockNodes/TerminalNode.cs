namespace ParaPen.Models.CustomGraph.BlockNodes;

public class TerminalNode : BlockNode
{
	public string Label { get; init; } = null!;

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
