namespace ParaPen.Models.Blocks;

public abstract class BlockNode
{
	//public int Id => GetHashCode();
	public string Label { get; init; } = null!;

	public abstract bool Execute();

	public override string ToString()
	{
		return Label;
	}
}
