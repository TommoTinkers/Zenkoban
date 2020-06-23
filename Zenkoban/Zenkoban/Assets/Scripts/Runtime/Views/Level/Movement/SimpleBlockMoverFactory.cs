namespace Zenkoban.Runtime.Views.Level.Movement
{
	public class SimpleBlockMoverFactory : IBlockMoverFactory
	{
		public IBlockMover Get()
		{
			return new BlockMover();
		}
	}
}