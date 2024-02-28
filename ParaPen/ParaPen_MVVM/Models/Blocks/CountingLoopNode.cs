namespace ParaPen.Models.Blocks;

public class CountingLoopNode : BlockNode
{
	private uint _count;

	public CountingLoopNode(string label, uint count)
	{
		Label = label;
		_count = count;
	}

	/// <returns>
	///		<see langword="true"/>:<br/>
	///			<see langword="if"/> counting loop is still in process (<see cref="_count"/> > 0)<br/>
	///		<see langword="false"/>:<br/>
	///		otherwise
	/// </returns>
	public override bool Execute()
	{
		if (_count == 0) 
		{
			return false;
		}
		_count--;
		return true;
	}
}
