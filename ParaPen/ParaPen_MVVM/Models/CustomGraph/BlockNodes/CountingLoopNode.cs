using ParaPen.Models.Interfaces;
using System;
using System.Runtime.Serialization;

namespace ParaPen.Models.CustomGraph.BlockNodes;

[DataContract]
public class CountingLoopNode : BlockNode, IResetable
{
	private readonly uint _count;


	[DataMember]
    public uint Count { get; set; }


	[Obsolete]
    public CountingLoopNode() 
	{ 
		// Восстанавливаем значение после десериализации
		_count = Count; 
	}

    public CountingLoopNode(uint count)
	{
		_count = count;
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
		Count = _count;
		base.Reset();
	}
}
