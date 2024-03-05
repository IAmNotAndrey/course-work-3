using System.Diagnostics;

namespace ParaPen.Models.CustomGraph;

[DebuggerDisplay("{Label}")]
public abstract class BlockNode
{
	public string Id { get; init; }	

	//public int Id => GetHashCode();
	public string Label { get; init; } = null!;

    public BlockNode(string id, string label)
    {
		Id = id;
		Label = label;
    }

    public abstract bool Execute();

	public override string ToString()
	{
		return Label;
	}
}
