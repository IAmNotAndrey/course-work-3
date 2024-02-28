namespace ParaPen.Models.Blocks;

public abstract class BlockNode<TResult>
{
	//public int Id => GetHashCode();
	public string Label { get; init; }

	public abstract TResult Execute();

	public override string ToString()
	{
		return Label;
	}
}
