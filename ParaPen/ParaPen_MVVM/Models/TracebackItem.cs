namespace ParaPen.Models;

public class TracebackItem
{
	public string Message { get; init; } = null!;
	public BlockPenContainer Container { get; init; } = null!;
}
