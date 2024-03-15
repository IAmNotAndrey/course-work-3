namespace ParaPen.Models.CustomGraph.BlockNodes;

public class CountingLoopNode : BlockNode
{
    private uint _count;

    //public CountingLoopNode(string label, uint count) : base(label)
    //{
    //    _count = count;
    //}
	public CountingLoopNode(uint count)
	{
		_count = count;

		Label = ToString();
		IsHighlighted = false;
	}

	/// <returns>
	///		<see langword="false"/>:<br/>
	///			<see langword="if"/> counting loop is still in process (<see cref="_count"/> > 0)<br/>
	///		<see langword="true"/>:<br/>
	///		otherwise
	/// </returns>
	public override bool Execute()
    {
        if (_count == 0)
        {
            return true;
        }
        _count--;
        return false;
    }

	public override string ToString()
	{
		return $"{nameof(CountingLoopNode)}-{_count}";
	}
}
