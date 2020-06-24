namespace Zenkoban.Data.Levels
{
	public class LevelPoint
	{
		public int X { get; }
		public int Y { get; }

		public LevelPoint(int x, int y)
		{
			X = x;
			Y = y;
		}

		public static LevelPoint operator+(LevelPoint left, LevelPoint right)
		{
			return new LevelPoint(left.X + right.X, left.Y + right.Y);
		}
		
	}
}