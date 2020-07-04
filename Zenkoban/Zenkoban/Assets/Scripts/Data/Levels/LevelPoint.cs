using System.Collections.Generic;
using Zenkoban.Runtime.Data.Movement;

namespace Zenkoban.Data.Levels
{
	public class LevelPoint
	{
		private static readonly Dictionary<MoveDirection, LevelPoint> offsets = new Dictionary<MoveDirection, LevelPoint>
		{
			{MoveDirection.Up, new LevelPoint(0, 1)},
			{MoveDirection.Down, new LevelPoint(0,  - 1)},
			{MoveDirection.Right, new LevelPoint(1, 0)},
			{MoveDirection.Left, new LevelPoint(- 1, 0)}
		};
		
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

		public static LevelPoint operator+(LevelPoint left, MoveDirection direction)
		{
			return left + offsets[direction];
		}
	}
}