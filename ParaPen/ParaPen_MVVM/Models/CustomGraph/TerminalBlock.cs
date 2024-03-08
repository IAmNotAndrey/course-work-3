namespace ParaPen.Models.CustomGraph;

public class TerminalBlock : BlockNode
{
	public TerminalBlock(string label) : base(label) { }

	public override bool Execute() { return true; }
}
