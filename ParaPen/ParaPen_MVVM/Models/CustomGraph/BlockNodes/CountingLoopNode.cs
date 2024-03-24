using ParaPen.Models.Interfaces;
using System;
using System.Runtime.Serialization;

namespace ParaPen.Models.CustomGraph.BlockNodes;

[DataContract]
public class CountingLoopNode : BlockNode, IResetable
{
	[DataMember]
	public uint UnchangingCount { get; init; }


	[IgnoreDataMember]
    public uint Count { get; set; }


	[Obsolete]
	public CountingLoopNode() { }

    public CountingLoopNode(uint count)
	{
		UnchangingCount = count;
		Count = count;

		Label = ToString();
		IsHighlighted = false;
	}

	/// <returns>
	///		<see langword="false"/>:<br/>
	///			<see langword="if"/> counting loop is still in process (<see cref="Count"/> > 0)<br/>
	///		<see langword="true"/>:<br/>
	///			otherwise
	/// </returns>
	public override bool Execute()
    {
        if (Count == 0)
        {
			Reset();
            return true;
        }
        Count--;
        return false;
    }

	public override string ToString()
	{
		return $"{nameof(CountingLoopNode)}-{Count}";
	}

	public override void Reset()
	{
		Count = UnchangingCount;
		base.Reset();
	}
}
