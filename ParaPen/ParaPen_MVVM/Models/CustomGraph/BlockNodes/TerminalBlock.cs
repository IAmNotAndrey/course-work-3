namespace ParaPen.Models.CustomGraph.BlockNodes;

public class TerminalBlock : BlockNode
{
    public TerminalBlock(string label) : base(label) { }

    public override bool Execute() { return true; }
}
