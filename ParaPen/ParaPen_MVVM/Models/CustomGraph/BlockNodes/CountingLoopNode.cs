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
	///		<see langword="true"/>:<br/>
	///			<see langword="if"/> counting loop is still in process (<see cref="Count"/> > 0)<br/>
	///		<see langword="false"/>:<br/>
	///			otherwise
	/// </returns>
	public override bool Execute()
    {
        if (Count == 0)
        {
			Reset();
            return false;
        }
        Count--;
        return true;
    }

	public override string ToString()
	{
		return $"CountingLoop-{Count}";
	}

	public override void Reset()
	{
		Count = UnchangingCount;
		base.Reset();
	}
}
