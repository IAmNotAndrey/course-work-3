using QuickGraph;
using System.Diagnostics;

namespace ParaPen.Models.CustomGraph;

[DebuggerDisplay("{Id}-{Label}")]	
public class BlockEdge : IEdge<object>
{
	public string Id { get; init; }
	public string? Label { get; init; }

	public object Source { get; init; }
	public object Target { get; init; }


	public BlockEdge(string id, string? label, object source, object target)
	{
		Id = id;
		Label = label;
		Source = source;
		Target = target;
	}
}
