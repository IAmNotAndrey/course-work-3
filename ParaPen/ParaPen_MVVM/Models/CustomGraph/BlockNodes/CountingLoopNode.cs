using System;
using System.Runtime.Serialization;

namespace ParaPen.Models.CustomGraph.BlockNodes;

//[Serializable]
[DataContract]
public class CountingLoopNode : BlockNode
{
	[DataMember]
    public uint Count { get; set; }

    //public CountingLoopNode(string label, uint count) : base(label)
    //{
    //    _count = count;
    //}

	[Obsolete]
    public CountingLoopNode() { }

    public CountingLoopNode(uint count)
	{
		Count = count;

		Label = ToString();
		IsHighlighted = false;
	}

	/// <returns>
	///		<see langword="false"/>:<br/>
	///			<see langword="if"/> counting loop is still in process (<see cref="Count"/> > 0)<br/>
	///		<see langword="true"/>:<br/>
	///		otherwise
	/// </returns>
	public override bool Execute()
    {
        if (Count == 0)
        {
            return true;
        }
        Count--;
        return false;
    }

	public override string ToString()
	{
		return $"{nameof(CountingLoopNode)}-{Count}";
	}
}
